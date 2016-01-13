using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TraceCtrlLib.PanelExtend
{
    public class TracePanelManage
    {
        private readonly List<TracePanel> _tracePanelColl;
        private readonly Hashtable _traceChainEntityHashtable;
        private Control _container;
        public TracePanelManage(Control container)
        {
            _container = container;
            //_container.Paint += ContainerOnPaint;
            _tracePanelColl = new List<TracePanel>();
            _traceChainEntityHashtable = new Hashtable();
            Point offset = new Point();
            CollectTracePanel(container, offset,  ref _tracePanelColl);
            ArrangeAnchorCtrls();
        }

        private void CollectTracePanel(Control host, Point offset, ref List<TracePanel> tracePanels)
        {
            if (host == null)
                return;
            if (tracePanels == null)
                tracePanels = new List<TracePanel>();
            foreach (Control child in host.Controls.Cast<Control>().Where(child => child.GetType() == typeof (TracePanel)))
                AddTracePanel((TracePanel)child, offset);
            foreach (Control child in host.Controls.Cast<Control>().Where(child => child.GetType() != typeof (TracePanel)))
            {
                Point newOffset = new Point(offset.X,offset.Y);
                newOffset.Offset(child.Location);
                CollectTracePanel(child, newOffset, ref tracePanels);
            }
        }

        private void AddTracePanel(TracePanel traceAdd, Point offset)
        {
            if (null == _tracePanelColl)
                return;
            if (_tracePanelColl.Contains(traceAdd))
                return;
            traceAdd.Offset = offset;
            _tracePanelColl.Add(traceAdd);
        }

        private void ContainerOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            
        }

        private void ArrangeAnchorCtrls()
        {
            foreach (TracePanel tpChild in _tracePanelColl)
            {
                //Debug.Print(tpChild.DisplayText);
                foreach (TracePanel anchor in _tracePanelColl)
                {
                    //Debug.Print(anchor.DisplayText);
                    if (anchor.Bottom + anchor.Offset.Y == tpChild.Top + tpChild.Offset.Y)//Top
                    {
                        int anchorLeft = anchor.Left + anchor.Offset.X;
                        int childLeft = tpChild.Left + tpChild.Offset.X;
                        int anchorOpenLeft = (int)(anchor.Left + anchor.Width * anchor.OpenStart) + anchor.Offset.X;
                        int anchorOpenRight = (int)(anchor.Left + anchor.Width * (anchor.OpenStart + anchor.OpenRatio)) + anchor.Offset.X;
                        int childOpenLeft = tpChild.Left + (int)(tpChild.Width * tpChild.OpenStart) + tpChild.Offset.X;
                        int childOpenRight = tpChild.Left + (int)(tpChild.Width * (tpChild.OpenStart + tpChild.OpenRatio)) + tpChild.Offset.X;

                        if ((anchor.OpenAt & AnchorStyles.Bottom) != AnchorStyles.None && (tpChild.OpenAt & AnchorStyles.Top) != AnchorStyles.None 
                            && GlobalMethod.HasIntersection(anchorOpenLeft, anchorOpenRight, childOpenLeft, childOpenRight))
                            tpChild.AddAnchor(anchor, AnchorStyles.Top, true);
                        else if (GlobalMethod.HasIntersection(anchorLeft, anchorLeft + anchor.Width, childLeft, childLeft + tpChild.Width))
                            tpChild.AddAnchor(anchor, AnchorStyles.Top, false);
                    }
                    else if (anchor.Top + anchor.Offset.Y == tpChild.Bottom + tpChild.Offset.Y)//Bottom
                    {
                        int anchorLeft = anchor.Left + anchor.Offset.X;
                        int childLeft = tpChild.Left + tpChild.Offset.X;
                        int anchorOpenLeft = (int)(anchor.Left + anchor.Width * anchor.OpenStart) + anchor.Offset.X;
                        int anchorOpenRight = (int)(anchor.Left + anchor.Width * (anchor.OpenStart + anchor.OpenRatio)) + anchor.Offset.X;
                        int childOpenLeft = tpChild.Left + (int)(tpChild.Width * tpChild.OpenStart) + tpChild.Offset.X;
                        int childOpenRight = tpChild.Left + (int)(tpChild.Width * (tpChild.OpenStart + tpChild.OpenRatio)) + tpChild.Offset.X;

                        if ((anchor.OpenAt & AnchorStyles.Top) != AnchorStyles.None && (tpChild.OpenAt & AnchorStyles.Bottom) != AnchorStyles.None 
                             && GlobalMethod.HasIntersection(anchorOpenLeft, anchorOpenRight, childOpenLeft, childOpenRight))
                            tpChild.AddAnchor(anchor, AnchorStyles.Bottom, true);
                        else if (GlobalMethod.HasIntersection(anchorLeft, anchorLeft + anchor.Width, childLeft, childLeft + tpChild.Width))
                            tpChild.AddAnchor(anchor, AnchorStyles.Bottom, false);
                    }
                    else if (anchor.Right + anchor.Offset.X == tpChild.Left + tpChild.Offset.X)//Left
                    {
                        int anchorTop = anchor.Top + anchor.Offset.Y;
                        int childTop = tpChild.Top + tpChild.Offset.Y;
                        int anchorOpenTop = (int)(anchor.Top + anchor.Height * anchor.OpenStart) + anchor.Offset.Y;
                        int anchorOpenBottom = (int)(anchor.Top + anchor.Height * (anchor.OpenStart + anchor.OpenRatio)) + anchor.Offset.Y;
                        int childOpenTop = tpChild.Top + (int)(tpChild.Height * tpChild.OpenStart) + tpChild.Offset.Y;
                        int childOpenBottom = tpChild.Top + (int)(tpChild.Height * (tpChild.OpenStart + tpChild.OpenRatio)) + tpChild.Offset.Y;

                        if ((anchor.OpenAt & AnchorStyles.Right) != AnchorStyles.None && (tpChild.OpenAt & AnchorStyles.Left) != AnchorStyles.None 
                           && GlobalMethod.HasIntersection(anchorOpenTop, anchorOpenBottom, childOpenTop, childOpenBottom))
                            tpChild.AddAnchor(anchor, AnchorStyles.Left, true);
                        else if (GlobalMethod.HasIntersection(anchorTop, anchorTop + anchor.Height, childTop, childTop + tpChild.Height))
                            tpChild.AddAnchor(anchor, AnchorStyles.Left, false);
                    }
                    else if (anchor.Left + anchor.Offset.X == tpChild.Right + tpChild.Offset.X)//Right
                    {
                        int anchorTop = anchor.Top + anchor.Offset.Y;
                        int childTop = tpChild.Top + tpChild.Offset.Y;
                        int anchorOpenTop = (int)(anchor.Top + anchor.Height * anchor.OpenStart) + anchor.Offset.Y;
                        int anchorOpenBottom = (int)(anchor.Top + anchor.Height * (anchor.OpenStart + anchor.OpenRatio)) + anchor.Offset.Y;
                        int childOpenTop = tpChild.Top + (int)(tpChild.Height * tpChild.OpenStart) + tpChild.Offset.Y;
                        int childOpenBottom = tpChild.Top + (int)(tpChild.Height * (tpChild.OpenStart + tpChild.OpenRatio)) + tpChild.Offset.Y;

                        if ((anchor.OpenAt & AnchorStyles.Left) != AnchorStyles.None && (tpChild.OpenAt & AnchorStyles.Right) != AnchorStyles.None 
                            && GlobalMethod.HasIntersection(anchorOpenTop, anchorOpenBottom, childOpenTop, childOpenBottom))
                            tpChild.AddAnchor(anchor, AnchorStyles.Right, true);
                        else if (GlobalMethod.HasIntersection(anchorTop, anchorTop + anchor.Height, childTop, childTop + tpChild.Height))
                            tpChild.AddAnchor(anchor, AnchorStyles.Right, false);
                    }
                }
            }
        }

        public bool TraceFromTo(String entity, TracePanel start, TracePanel dest)
        {
            if (string.IsNullOrEmpty(entity) || null == start || dest == null)
                return false;

            List<TracePanel> traceNodes = new List<TracePanel>();
            TraceNodes(start, dest, ref traceNodes, new List<TracePanel>());
            if (traceNodes.Count <= 0 || !traceNodes.Contains(dest))
                return false;
            AddTrace(entity,traceNodes);
            return true;
        }

        public bool TraceFromTo(String entity, String start, String dest)
        {
            TracePanel tpStart = _tracePanelColl.First(o => o.Name == start);
            TracePanel tpDest = _tracePanelColl.First(o => o.Name == dest);
            return TraceFromTo(entity, tpStart, tpDest);
        }

        private void TraceNodes(TracePanel start, TracePanel dest, ref List<TracePanel> traceNodes, List<TracePanel> curTraceNodes)
        {
            if (curTraceNodes.Contains(start))//如果当前路径中已经包含该节点，则返回，防止类似A-B，陷入无限循环中
                return;
            curTraceNodes.Add(start);
            if (!traceNodes.IsNullOrEmpty() && traceNodes.Count <= curTraceNodes.Count)//如果当前路径长度大于记录路径，则直接返回
                return;
            if (start == dest) //如果已经到达最终节点
            {
                if (traceNodes.Count==0 || traceNodes.Count > curTraceNodes.Count)
                {
                    traceNodes.Clear();
                    traceNodes = new List<TracePanel>(curTraceNodes);
                }
            }
            else//遍历子节点
            {
                List<TracePanel> anchorTotal = (from ae in start.AnchorTop where ae.Intersectioned select ae.Anchor).ToList();
                anchorTotal.AddRange(from ae in start.AnchorBottom where ae.Intersectioned select ae.Anchor);
                anchorTotal.AddRange(from ae in start.AnchorLeft where ae.Intersectioned select ae.Anchor);
                anchorTotal.AddRange(from ae in start.AnchorRight where ae.Intersectioned select ae.Anchor);

                foreach (TracePanel tpChild in anchorTotal)
                {
                    List<TracePanel> nexTracePanels = new List<TracePanel>(curTraceNodes);
                    TraceNodes(tpChild, dest, ref traceNodes, nexTracePanels);
                }
            }
        }

        private void AddTrace(String entity, List<TracePanel> traceNodes)
        {
            if (String.IsNullOrEmpty(entity) || traceNodes.IsNullOrEmpty())
                return;
            if (_traceChainEntityHashtable.Contains(entity))
            {
                List<TracePanel> entityTraceNodes = (List<TracePanel>) _traceChainEntityHashtable[entity];
                if (traceNodes.First(p => true) == entityTraceNodes.Last(p => true))
                {
                    traceNodes.RemoveAt(0);
                    entityTraceNodes.AddRange(traceNodes);
                    _traceChainEntityHashtable[entity] = entityTraceNodes;
                }
                else
                    return;
            }
            else
                _traceChainEntityHashtable.Add(entity,traceNodes);

            traceNodes = (List<TracePanel>)_traceChainEntityHashtable[entity];
            foreach (TracePanel tp in traceNodes)
                tp.ClearTrace(entity);
            for (int i = 0; i < traceNodes.Count; i++)
            {
                TracePanel tpPre = null;
                TracePanel tpNext = null;
                if (i > 0)
                    tpPre = traceNodes[i-1];
                if (i < traceNodes.Count - 1)
                    tpNext = traceNodes[i + 1];
                traceNodes[i].AddTraceChain(entity, tpPre, tpNext);
                traceNodes[i].Refresh();
            }
        }
        
        public void ClearTrace()
        {
            foreach (TracePanel tpChild in _tracePanelColl)
                tpChild.ClearAllTrace();
            _traceChainEntityHashtable.Clear();
        }

        public void ClearMonitor()
        {
            foreach (TracePanel tpChild in _tracePanelColl)
                tpChild.ClearAllMonitor();
        }

        public bool AddMonitor(string tcName, TraceMonitorPoint hint)
        {
            TracePanel target = _tracePanelColl.First(o => o.Name == tcName);
            if (null == target)
                return false;
            target.AddMonitor(hint);
            return true;
        }
    }
}
