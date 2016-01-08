using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TraceCtrlLib.PanelExtend
{
    public class TracePanel : Panel
    {
        private const int RoundRadius = 0;
        private const int DoorOffset = 4;
        private const int DrawBorderWidthLitter = 3;
        private const int DrawBorderWidthBig = 6;
        private const int DrawDoorWidth = 1;
        private const int DrawTextWidth = 12;
        private readonly Color _borderColor = Color.Black;
        private const int DrawTraceWidth = 2;
        private const int TracePointRadius = 4;
        private const int DrawMonitorWidth = 1;
        private const int MonitorPointRadius = 6; 
        private const int TracePointOffset = 0;
        private readonly Color _traceColor = Color.DodgerBlue;
        private readonly Color _traceStartColor = Color.Green;
        private readonly Color _traceEndColor = Color.Red;
        private readonly Color _traceGobyColor = Color.Yellow;
        private readonly Color _traceText = Color.Black;
        private readonly List<TraceChain> _traceChains;
        private readonly List<TraceMonitorPoint> _monitorPoints;

        [Localizable(true)]
        [DefaultValue(AnchorStyles.None)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public virtual AnchorStyles OpenAt { get; set; }

        [Localizable(true)]
        [DefaultValue(AnchorStyles.None)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public virtual AnchorStyles DoorAt { get; set; }

        public DoorStyle DoorStyle { get; set; }

        private double _openRatio = 0.0;
        [DefaultValue(0.0)]
        public double OpenRatio {
            get { return _openRatio; }
            set
            {
                if (value < 0 || value>1) throw new ArgumentOutOfRangeException("合法值应介于0~1之间。");
                _openRatio = value;
            } 
        }
        private double _openStart = 0.0;
        [DefaultValue(0.0)]
        public double OpenStart
        {
            get { return _openStart; }
            set
            {
                if (value < 0 || value > (1- _openRatio)) throw new ArgumentOutOfRangeException("合法值应该介于0和1-OpenRatio之间。");
                _openStart = value;
            }
        }
        public string DisplayText { get; set; }

        [Browsable(false)]
        public Point Offset { get; set; }

        public List<AnchorEntity> AnchorLeft;

        public List<AnchorEntity> AnchorRight;

        public List<AnchorEntity> AnchorTop;

        public List<AnchorEntity> AnchorBottom;

        public TracePanel()
        {
            _traceChains = new List<TraceChain>();
            _monitorPoints = new List<TraceMonitorPoint>();
            AnchorLeft = new List<AnchorEntity>();
            AnchorRight = new List<AnchorEntity>();
            AnchorTop = new List<AnchorEntity>();
            AnchorBottom = new List<AnchorEntity>();
            Offset = new Point();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBorder();
            DrawDoor();
            DrawText();
            DrawTrace();
            DrawMonitor();
            base.OnPaint(e);
        }

        #region "Drawing"

        private void DrawBorder()
        {
            double borderOpenRatio = _openRatio;
            double borderOpenStart = _openStart;
            Pen pL = new Pen(_borderColor, DrawBorderWidthLitter);
            Pen pB = new Pen(_borderColor, DrawBorderWidthBig);
            Graphics g = CreateGraphics();
            if (AnchorTop.Count > 0)
            {
                foreach (AnchorEntity ae in AnchorTop)
                {
                    if (ae.Intersectioned) //有交集
                    {
                        int leftStartP = Offset.X + Left;
                        int leftAnchorStartP = ae.Anchor.Offset.X + ae.Anchor.Left;
                        int leftEndP = leftStartP + (int) (Width*OpenStart);
                        int leftAnchorEndP = leftAnchorStartP + (int)(ae.Anchor.Width * ae.Anchor.OpenStart);
                        g.DrawLine(pL, Math.Max(leftStartP, leftAnchorStartP) - Offset.X - Left - RoundRadius, 0, Math.Max(leftEndP, leftAnchorEndP) - Offset.X - Left, 0);

                        int rightStartP = leftStartP + (int) (Width*(OpenRatio + OpenStart));
                        int rightAnchorStartP = leftAnchorStartP + (int)(ae.Anchor.Width*(ae.Anchor.OpenStart + ae.Anchor.OpenRatio));
                        g.DrawLine(pL, Math.Min(rightStartP, rightAnchorStartP) - Offset.X - Left, 0, Math.Min(leftStartP + Width, leftAnchorStartP + ae.Anchor.Width) - Offset.X - Left + RoundRadius, 0);
                    }
                    else
                    {
                        int startP = Offset.X + Left;
                        int anchorStartP = ae.Anchor.Offset.X + ae.Anchor.Left;
                        g.DrawLine(pL, Math.Max(startP, anchorStartP) - Offset.X - Left - RoundRadius, 0, Math.Min(startP + Width, anchorStartP + ae.Anchor.Width) - Offset.X - Left + RoundRadius, 0);
                    }
                }
            }
            else
            {
                if ((OpenAt & AnchorStyles.Top) != AnchorStyles.None)
                {
                    g.DrawLine(pB, 0, 0, (int)(Width * borderOpenStart), 0);
                    g.DrawLine(pB, (int)(Width * (borderOpenRatio + borderOpenStart)), 0, Width, 0);
                }
                else
                {
                    g.DrawLine(pB, 0, 0, Width, 0);
                }
            }
            

            //Bottom
            if (AnchorBottom.Count > 0)
            {
                foreach (AnchorEntity ae in AnchorBottom)
                {
                    if (ae.Intersectioned) //有交集
                    {
                        int leftStartP = Offset.X + Left;
                        int leftAnchorStartP = ae.Anchor.Offset.X + ae.Anchor.Left;
                        int leftEndP = leftStartP + (int)(Width * OpenStart);
                        int leftAnchorEndP = leftAnchorStartP + (int)(ae.Anchor.Width * ae.Anchor.OpenStart);
                        g.DrawLine(pL, Math.Max(leftStartP, leftAnchorStartP) - Offset.X - Left - RoundRadius, Height, Math.Max(leftEndP, leftAnchorEndP) - Offset.X - Left, Height);

                        int rightStartP = leftStartP + (int)(Width * (OpenRatio + OpenStart));
                        int rightAnchorStartP = leftAnchorStartP + (int)(ae.Anchor.Width * (ae.Anchor.OpenStart + ae.Anchor.OpenRatio));
                        g.DrawLine(pL, Math.Min(rightStartP, rightAnchorStartP) - Offset.X - Left, Height, Math.Min(leftStartP + Width, leftAnchorStartP + ae.Anchor.Width) - Offset.X - Left + RoundRadius, Height);
                    }
                    else
                    {
                        int startP = Offset.X + Left;
                        int anchorStartP = ae.Anchor.Offset.X + ae.Anchor.Left;
                        g.DrawLine(pL, Math.Max(startP, anchorStartP) - Offset.X - Left - RoundRadius, Height, Math.Min(startP + Width, anchorStartP + ae.Anchor.Width) - Offset.X - Left + RoundRadius, Height);
                    }
                }
            }
            else
            {
                if ((OpenAt & AnchorStyles.Bottom) != AnchorStyles.None)
                {
                    g.DrawLine(pB, 0, Height, (int)(Width * borderOpenStart), Height);
                    g.DrawLine(pB, (int)(Width * (borderOpenRatio + borderOpenStart)), Height, Width, Height);
                }
                else
                {
                    g.DrawLine(pB, 0, Height, Width, Height);
                }
            }

            //Left
            if (AnchorLeft.Count > 0)
            {
                foreach (AnchorEntity ae in AnchorLeft)
                {
                    if (ae.Intersectioned) //有交集
                    {
                        int topStartP = Offset.Y + Top;
                        int topAnchorStartP = ae.Anchor.Offset.Y + ae.Anchor.Top;
                        int topEndP = topStartP + (int)(Height * OpenStart);
                        int topAnchorEndP = topAnchorStartP + (int)(ae.Anchor.Height * ae.Anchor.OpenStart);
                        g.DrawLine(pL, 0, Math.Max(topStartP, topAnchorStartP) - Offset.Y - Top - RoundRadius, 0, Math.Max(topEndP, topAnchorEndP) - Offset.Y - Top);

                        int rightStartP = topStartP + (int)(Height * (OpenRatio + OpenStart));
                        int rightAnchorStartP = topAnchorStartP + (int)(ae.Anchor.Height * (ae.Anchor.OpenStart + ae.Anchor.OpenRatio));
                        g.DrawLine(pL, 0, Math.Min(rightStartP, rightAnchorStartP) - Offset.Y - Top, 0, Math.Min(topStartP + Height, topAnchorStartP + ae.Anchor.Height) - Offset.Y - Top + RoundRadius);
                    }
                    else
                    {
                        int startP = Offset.Y + Top;
                        int anchorStartP = ae.Anchor.Offset.Y + ae.Anchor.Top;
                        g.DrawLine(pL, 0, Math.Max(startP, anchorStartP) - Offset.Y - Top - RoundRadius, 0, Math.Min(startP + Height, anchorStartP + ae.Anchor.Height) - Offset.Y - Top + RoundRadius);
                    }
                }
            }
            else
            {
                if ((OpenAt & AnchorStyles.Left) != AnchorStyles.None)
                {
                    g.DrawLine(pB, 0, 0, 0, (int)(Height * borderOpenStart));
                    g.DrawLine(pB, 0, (int)(Height * (borderOpenRatio + borderOpenStart)), 0, Height);
                }
                else
                {
                    g.DrawLine(pB, 0, 0, 0, Height);
                }
            }

            //Right
            if (AnchorRight.Count > 0)
            {
                foreach (AnchorEntity ae in AnchorRight)
                {
                    if (ae.Intersectioned) //有交集
                    {
                        int topStartP = Offset.Y + Top;
                        int topAnchorStartP = ae.Anchor.Offset.Y + ae.Anchor.Top;
                        int topEndP = topStartP + (int)(Height * OpenStart);
                        int topAnchorEndP = topAnchorStartP + (int)(ae.Anchor.Height * ae.Anchor.OpenStart);
                        g.DrawLine(pL, Width, Math.Max(topStartP, topAnchorStartP) - Offset.Y - Top - RoundRadius, Width, Math.Max(topEndP, topAnchorEndP) - Offset.Y - Top);

                        int rightStartP = topStartP + (int)(Height * (OpenRatio + OpenStart));
                        int rightAnchorStartP = topAnchorStartP + (int)(ae.Anchor.Height * (ae.Anchor.OpenStart + ae.Anchor.OpenRatio));
                        g.DrawLine(pL, Width, Math.Min(rightStartP, rightAnchorStartP) - Offset.Y - Top, Width, Math.Min(topStartP + Height, topAnchorStartP + ae.Anchor.Height) - Offset.Y - Top + RoundRadius);
                    }
                    else
                    {
                        int startP = Offset.Y + Top;
                        int anchorStartP = ae.Anchor.Offset.Y + ae.Anchor.Top;
                        g.DrawLine(pL, Width, Math.Max(startP, anchorStartP) - Offset.Y - Top - RoundRadius, Width, Math.Min(startP + Height, anchorStartP + ae.Anchor.Height) - Offset.Y - Top + RoundRadius);
                    }
                }
            }
            else
            {
                if ((OpenAt & AnchorStyles.Right) != AnchorStyles.None)
                {
                    g.DrawLine(pB, Width, 0, Width, (int)(Height * borderOpenStart));
                    g.DrawLine(pB, Width, (int)(Height * (borderOpenRatio + borderOpenStart)), Width, Height);
                }
                else
                {
                    g.DrawLine(pB, Width, 0, Width, Height);
                }
            }

            g.Dispose();
            pL.Dispose();
            pB.Dispose();
        }

        private void DrawDoor()
        {
            Pen p = new Pen(_borderColor, DrawDoorWidth);
            Graphics g = CreateGraphics();

            if ((DoorAt & AnchorStyles.Top) != AnchorStyles.None)
            {
                if (DoorStyle == DoorStyle.一扇)
                {
                    int doorWidth = (int)(Width * OpenRatio)-DoorOffset;
                    if (OpenStart <= 1 - OpenStart - OpenRatio)//靠近左部
                    {
                        g.DrawLine(p, DoorOffset + (int)(Width * OpenStart), 0, DoorOffset + (int)(Width * OpenStart), doorWidth);
                        g.DrawArc(p, DoorOffset + (int)(Width * OpenStart) - doorWidth, -doorWidth, 2 * doorWidth, 2 * doorWidth, 0, 90);
                    }
                    else
                    {
                        g.DrawLine(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, 0, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, doorWidth);
                        g.DrawArc(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset - doorWidth, -doorWidth, 2 * doorWidth, 2 * doorWidth, 90, 90);
                    }
                }
                else if (DoorStyle == DoorStyle.二扇)
                {
                    int doorWidth = ((int)(Width * OpenRatio) - 2 * DoorOffset) / 2;
                    g.DrawLine(p, (int)(Width * OpenStart) + DoorOffset, 0, (int)(Width * OpenStart) + DoorOffset, doorWidth);
                    g.DrawArc(p, DoorOffset + (int)(Width * OpenStart) - doorWidth, -doorWidth, 2 * doorWidth, 2 * doorWidth, 0, 90);
                    g.DrawLine(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, 0, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, doorWidth);
                    g.DrawArc(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset - doorWidth, -doorWidth, 2 * doorWidth, 2 * doorWidth, 90, 90);
                }
            }
            if ((DoorAt & AnchorStyles.Bottom) != AnchorStyles.None)
            {
                if (DoorStyle == DoorStyle.一扇)
                {
                    int doorWidth = (int)(Width * OpenRatio) - DoorOffset;
                    if (OpenStart <= 1 - OpenStart - OpenRatio)//靠近左部
                    {
                        g.DrawLine(p, DoorOffset + (int)(Width * OpenStart), Height, DoorOffset + (int)(Width * OpenStart), Height - doorWidth);
                        g.DrawArc(p, DoorOffset + (int)(Width * OpenStart) - doorWidth, Height - doorWidth, 2 * doorWidth, 2 * doorWidth, 270, 90);
                    }
                    else
                    {
                        g.DrawLine(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, Height, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, Height - doorWidth);
                        g.DrawArc(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset - doorWidth, Height - doorWidth, 2 * doorWidth, 2 * doorWidth, 180, 90);
                    }
                }
                else if (DoorStyle == DoorStyle.二扇)
                {
                    int doorWidth = ((int)(Width * OpenRatio) - 2 * DoorOffset) / 2;
                    g.DrawLine(p, DoorOffset + (int)(Width * OpenStart), Height, DoorOffset + (int)(Width * OpenStart), Height - doorWidth);
                    g.DrawArc(p, DoorOffset + (int)(Width * OpenStart) - doorWidth, Height - doorWidth, 2 * doorWidth, 2 * doorWidth, 270, 90);
                    g.DrawLine(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, Height, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset, Height - doorWidth);
                    g.DrawArc(p, (int)(Width * OpenStart + Width * OpenRatio) - DoorOffset - doorWidth, Height - doorWidth, 2 * doorWidth, 2 * doorWidth, 180, 90);
                }
            }
            if ((DoorAt & AnchorStyles.Left) != AnchorStyles.None)
            {
                if (DoorStyle == DoorStyle.一扇)
                {
                    int doorWidth = (int)(Height * OpenRatio) - DoorOffset;
                    if (OpenStart <= 1 - OpenStart - OpenRatio)//靠近左部
                    {
                        g.DrawLine(p, 0, DoorOffset + (int)(Height * OpenStart), doorWidth, DoorOffset + (int)(Height * OpenStart));
                        g.DrawArc(p, -doorWidth, DoorOffset + (int)(Height * OpenStart) - doorWidth, 2 * doorWidth, 2 * doorWidth, 0, 90);
                    }
                    else
                    {
                        g.DrawLine(p, 0, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset, doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset);
                        g.DrawArc(p, -doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset - doorWidth, 2 * doorWidth, 2 * doorWidth, 270, 90);
                    }
                }
                else if (DoorStyle == DoorStyle.二扇)
                {
                    int doorWidth = ((int)(Height * OpenRatio) - 2 * DoorOffset) / 2;
                    g.DrawLine(p, 0, DoorOffset + (int)(Height * OpenStart), doorWidth, DoorOffset + (int)(Height * OpenStart));
                    g.DrawArc(p, -doorWidth, DoorOffset + (int)(Height * OpenStart) - doorWidth, 2 * doorWidth, 2 * doorWidth, 0, 90);
                    g.DrawLine(p, 0, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset, doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset);
                    g.DrawArc(p, -doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset - doorWidth, 2 * doorWidth, 2 * doorWidth, 270, 90);
                }
            }
            if ((DoorAt & AnchorStyles.Right) != AnchorStyles.None)
            {
                if (DoorStyle == DoorStyle.一扇)
                {
                    int doorWidth = (int)(Height * OpenRatio) - DoorOffset;
                    if (OpenStart <= 1 - OpenStart - OpenRatio)//靠近左部
                    {
                        g.DrawLine(p, Width, DoorOffset + (int)(Height * OpenStart), Width-doorWidth, DoorOffset + (int)(Height * OpenStart));
                        g.DrawArc(p, Width-doorWidth, DoorOffset + (int)(Height * OpenStart) - doorWidth, 2 * doorWidth, 2 * doorWidth, 90, 90);
                    }
                    else
                    {
                        g.DrawLine(p, Width, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset, Width - doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset);
                        g.DrawArc(p, Width - doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset - doorWidth, 2 * doorWidth, 2 * doorWidth, 180, 90);
                    }
                }
                else if (DoorStyle == DoorStyle.二扇)
                {
                    int doorWidth = ((int)(Height * OpenRatio) - 2 * DoorOffset) / 2;
                    g.DrawLine(p, Width, DoorOffset + (int)(Height * OpenStart), Width - doorWidth, DoorOffset + (int)(Height * OpenStart));
                    g.DrawArc(p, Width - doorWidth, DoorOffset + (int)(Height * OpenStart) - doorWidth, 2 * doorWidth, 2 * doorWidth, 90, 90);
                    g.DrawLine(p, Width, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset, Width - doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset);
                    g.DrawArc(p, Width - doorWidth, (int)(Height * OpenStart + Height * OpenRatio) - DoorOffset - doorWidth, 2 * doorWidth, 2 * doorWidth, 180, 90);
                }
            }

            g.Dispose();
            p.Dispose();
        }

        private void DrawText()
        {
            Font f = new Font("SimSun", DrawTextWidth, System.Drawing.FontStyle.Regular);
            SolidBrush b = new SolidBrush(_traceText);
            Graphics g = CreateGraphics();

            String text = DisplayText;
            SizeF textSize = g.MeasureString(text, f);
            
            float x = 0.0F;
            float y = 0.0F;
            StringFormat sf = new StringFormat();
            if (Height > Width) //如果高度大于长度，则竖排文字
            {
                x = (Width - textSize.Height - TracePointRadius) / 2;
                y =  (Height - textSize.Width - TracePointRadius) / 2;
                sf.FormatFlags |= StringFormatFlags.DirectionVertical;
            }
            else
            {
                x =  (Width - textSize.Width-TracePointRadius) / 2;
                y =  (Height - textSize.Height- TracePointRadius) /2;
            }
            g.DrawString(text,f,b,x,y, sf);

            g.Dispose();
            f.Dispose();
            b.Dispose();
        }

        private void DrawTrace()
        {
            Pen linePen = new Pen(_traceColor, DrawTraceWidth);
            Graphics g = CreateGraphics();

            foreach (TraceChain tc in _traceChains)
            {
                Point previous = GetAnchorPoint(tc.PreviousCtrl);//这个点以当前控件的父窗体为坐标系
                Point next = GetAnchorPoint(tc.NextCtrl);
                if (tc.PreviousCtrl == tc.NextCtrl)
                    next = Bounds.CenterPoint();
                RectangleF inflateBounds = new Rectangle(Bounds.Location,Bounds.Size);
                inflateBounds.Inflate(-0.1f,-0.1f);
                if (!previous.IsEmpty && !next.IsEmpty) //不是起点和终点
                {
                    Point anglePoint1 = new Point(previous.X, next.Y);
                    Point anglePoint2 = new Point(next.X, previous.Y);
                    SolidBrush brushTraceBy = new SolidBrush(_traceGobyColor);
                    if (inflateBounds.Contains(anglePoint1) || inflateBounds.Contains(anglePoint2))
                    {//若有一个折点位于空间内，则以此点为中转点
                        Point anglePoint = inflateBounds.Contains(anglePoint1) ? anglePoint1 : anglePoint2;
                        previous.Offset(-Location.X,-Location.Y);
                        anglePoint.Offset(-Location.X, -Location.Y);
                        next.Offset(-Location.X, -Location.Y);
                        g.DrawLines(linePen, new Point[] { previous , anglePoint , next });
                        if (tc.PreviousCtrl != tc.NextCtrl)
                            g.FillEllipse(brushTraceBy, new Rectangle(anglePoint.X - TracePointRadius, anglePoint.Y - TracePointRadius, TracePointRadius*2, TracePointRadius*2));
                        else
                            g.FillEllipse(brushTraceBy, new Rectangle(next.X - TracePointRadius, next.Y - TracePointRadius, TracePointRadius * 2, TracePointRadius * 2));
                    }
                    else
                    {
                        Point intermediatePoint = new Point((previous.X+next.X)/2, (previous.Y+ next.Y)/2);//中点，若中点位于空间内，则以此点作为中转点
                        if (!inflateBounds.Contains(intermediatePoint))//若中点不位于空间内，则以空间中点作为中转点
                            intermediatePoint = Bounds.CenterPoint();
                        Point centerAnglePoint1 = new Point(previous.X, intermediatePoint.Y);
                        Point centerAnglePoint2 = new Point(intermediatePoint.X, previous.Y);
                        Point centerAnglePointPrev = inflateBounds.Contains(centerAnglePoint1) ? centerAnglePoint1 : centerAnglePoint2;
                        centerAnglePoint1 = new Point(next.X, intermediatePoint.Y);
                        centerAnglePoint2 = new Point(intermediatePoint.X, next.Y);
                        Point centerAnglePointNext = inflateBounds.Contains(centerAnglePoint1) ? centerAnglePoint1 : centerAnglePoint2;
                        previous.Offset(-Location.X, -Location.Y);//转变为控件本身为坐标系的点
                        centerAnglePointPrev.Offset(-Location.X, -Location.Y);
                        centerAnglePointNext.Offset(-Location.X, -Location.Y);
                        next.Offset(-Location.X, -Location.Y);
                        intermediatePoint.Offset(-Location.X, -Location.Y);
                        g.DrawLines(linePen,new Point[] { previous, centerAnglePointPrev, centerAnglePointNext, next });
                        
                        g.FillEllipse(brushTraceBy, new Rectangle(intermediatePoint.X - TracePointRadius, intermediatePoint.Y - TracePointRadius, TracePointRadius * 2, TracePointRadius * 2));
                    }
                    brushTraceBy.Dispose();
                }
                else if (previous.IsEmpty && next.IsEmpty)
                    continue;
                else //如果是起点，或者是终点
                {
                    Point anchorPoint = previous.IsEmpty ? next : previous;
                    Point intermediatePoint = Bounds.CenterPoint();
                    intermediatePoint.X += previous.IsEmpty ? -TracePointOffset * 2 : TracePointOffset * 2;
                    SolidBrush brushSourceDest = new SolidBrush(previous.IsEmpty ? _traceStartColor : _traceEndColor);
                    Point anglePoint1 = new Point(anchorPoint.X, intermediatePoint.Y);
                    Point anglePoint2 = new Point(intermediatePoint.X, anchorPoint.Y);
                    Point anglePoint = inflateBounds.Contains(anglePoint1) ? anglePoint1 : anglePoint2;

                    anchorPoint.Offset(-Location.X, -Location.Y);
                    anglePoint.Offset(-Location.X, -Location.Y);
                    intermediatePoint.Offset(-Location.X, -Location.Y);
                    g.DrawLines(linePen, new Point[] { anchorPoint , anglePoint , intermediatePoint });
                    g.FillEllipse(brushSourceDest, new Rectangle(intermediatePoint.X - TracePointRadius, intermediatePoint.Y - TracePointRadius, TracePointRadius * 2, TracePointRadius * 2));
                    brushSourceDest.Dispose();
                }
            }

            g.Dispose();
            linePen.Dispose();
        }

        private void DrawMonitor()//Modify later to support multi
        {
            Graphics g = CreateGraphics();
            foreach (TraceMonitorPoint monitorPoint in _monitorPoints)
            {
                Pen p = new Pen(monitorPoint.Color, DrawMonitorWidth);
                SolidBrush sb = new SolidBrush(monitorPoint.Color);
                Point center = this.Bounds.CenterPoint();
                center.Offset(-Location.X, -Location.Y);
                g.FillEllipse(sb, new Rectangle(center.X - MonitorPointRadius, center.Y - MonitorPointRadius, MonitorPointRadius * 2, MonitorPointRadius * 2));
                g.DrawEllipse(p, center.X - MonitorPointRadius - 2 * DrawMonitorWidth, center.Y - MonitorPointRadius - 2 * DrawMonitorWidth, (2 * DrawMonitorWidth + MonitorPointRadius) * 2, (2 * DrawMonitorWidth + MonitorPointRadius) * 2);
                p.Dispose();
                sb.Dispose();
            }
            g.Dispose();
        }

        private Point GetAnchorPoint(TracePanel anchor)
        {
            Point anchorPoint = new Point();
            if (null != anchor)
            {
                if (AnchorTop.Contains(new AnchorEntity(){Anchor = anchor,Intersectioned = true}))
                {
                    int overlapLeft = Math.Max(Offset.X + Left + (int)(OpenStart * Width), anchor.Offset.X + anchor.Left + (int)(anchor.OpenStart * anchor.Width));
                    int overlapRight = Math.Min(Offset.X + Left + (int)((OpenStart + OpenRatio) * Width), anchor.Offset.X+anchor.Left + (int)((anchor.OpenStart + anchor.OpenRatio) * anchor.Width));
                    anchorPoint = new Point(overlapLeft + (overlapRight - overlapLeft) / 2 - Offset.X, Top);
                }
                else if (AnchorBottom.Contains(new AnchorEntity() { Anchor = anchor, Intersectioned = true }))
                {
                    int overlapLeft = Math.Max(Offset.X + Left + (int)(OpenStart * Width), anchor.Offset.X + anchor.Left + (int)(anchor.OpenStart * anchor.Width));
                    int overlapRight = Math.Min(Offset.X + Left + (int)((OpenStart + OpenRatio) * Width), anchor.Offset.X + anchor.Left + (int)((anchor.OpenStart + anchor.OpenRatio) * anchor.Width));
                    anchorPoint = new Point(overlapLeft + (overlapRight - overlapLeft) / 2 - Offset.X, Bottom);
                }
                else if (AnchorLeft.Contains(new AnchorEntity() { Anchor = anchor, Intersectioned = true }))
                {
                    int overlapTop = Math.Max(Offset.Y + Top + (int)(OpenStart * Height), anchor.Offset.Y + anchor.Top + (int)(anchor.OpenStart * anchor.Height));
                    int overlapBottom = Math.Min(Offset.Y + Top + (int)((OpenStart + OpenRatio) * Height), anchor.Offset.Y + anchor.Top + (int)((anchor.OpenStart + anchor.OpenRatio) * anchor.Height));
                    anchorPoint = new Point(Left, overlapTop + (overlapBottom - overlapTop) / 2 - Offset.Y);
                }
                else if (AnchorRight.Contains(new AnchorEntity() { Anchor = anchor, Intersectioned = true }))
                {
                    int overlapTop = Math.Max(Offset.Y + Top + (int)(OpenStart * Height), anchor.Offset.Y + anchor.Top + (int)(anchor.OpenStart * anchor.Height));
                    int overlapBottom = Math.Min(Offset.Y + Top + (int)((OpenStart + OpenRatio) * Height), anchor.Offset.Y + anchor.Top + (int)((anchor.OpenStart + anchor.OpenRatio) * anchor.Height));
                    anchorPoint = new Point(Right, overlapTop + (overlapBottom - overlapTop) / 2 - Offset.Y);
                }
            }
            return anchorPoint;
        }

        public void AddTraceChain(String entity, TracePanel pre, TracePanel next)
        {
            if ((null == pre && null == next) || string.IsNullOrEmpty(entity))
                return;
            TraceChain tc = new TraceChain() { PreviousCtrl=pre, NextCtrl = next,Entity = entity };
            if (!_traceChains.Contains(tc))
                _traceChains.Add(tc);
        }

        public void AddAnchor(TracePanel tc, AnchorStyles orientation, bool intersectioned)
        {
            if (null == tc)
                return;
            if (orientation == AnchorStyles.Left)
            {
                AnchorLeft.Add(new AnchorEntity() { Anchor = tc,Intersectioned = intersectioned});
            }
            else if (orientation == AnchorStyles.Right)
            {
                AnchorRight.Add(new AnchorEntity() { Anchor = tc, Intersectioned = intersectioned });
            }
            else if (orientation == AnchorStyles.Top)
            {
                AnchorTop.Add(new AnchorEntity() { Anchor = tc, Intersectioned = intersectioned });
            }
            else if (orientation == AnchorStyles.Bottom)
            {
                AnchorBottom.Add(new AnchorEntity() { Anchor = tc, Intersectioned = intersectioned });
            }
        }
        #endregion

        public void ClearAllTrace()
        {
            if (!_traceChains.IsNullOrEmpty())
            {
                _traceChains.Clear();
                Refresh();
            }
        }

        public void ClearTrace(string entity)
        {
            if (!_traceChains.IsNullOrEmpty() && !string.IsNullOrEmpty(entity))
            {
                _traceChains.RemoveAll(c => c.Entity == entity);
                Refresh();
            }
        }

        public void ClearAllMonitor()
        {
            if (!_monitorPoints.IsNullOrEmpty())
            {
                _monitorPoints.Clear();
                Refresh();
            }
        }

        public void AddMonitor(TraceMonitorPoint hint)
        {
            _monitorPoints.Add(hint);
            Refresh();
        }

        public void MouseHoverHandle(EventArgs e)
        {
            if (!_monitorPoints.IsNullOrEmpty())
            {
                Point center = this.Bounds.CenterPoint();
                center.Offset(-Location.X, -Location.Y);
                Rectangle hintRegion = new Rectangle(center.X - MonitorPointRadius - 2 * DrawMonitorWidth, center.Y - MonitorPointRadius - 2 * DrawMonitorWidth, (2 * DrawMonitorWidth + MonitorPointRadius) * 2, (2 * DrawMonitorWidth + MonitorPointRadius) * 2);
                if (hintRegion.Contains(this.PointToClient(MousePosition)))
                {
                    TraceMonitorPoint tmp = _monitorPoints[0];
                    String hint = String.Format("名      称：{0}\r\n进入时间：{1}", tmp.Name, tmp.Arrive);
                    ShowToolTip(hint);
                }
            }           
        }

        private void ShowToolTip(String hint)
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true,
                IsBalloon = true
            };
            toolTip1.SetToolTip(this, hint);
        }
    }

    public class TraceMonitorPoint
    {
        public String Name { get; set; }
        public String Arrive { get; set; }
        public String Leave { get; set; }
        public Color Color { get; set; }
        public Size Offset { get; set; }
    }

    public class AnchorEntity
    {
        protected bool Equals(AnchorEntity other)
        {
            return Equals(Anchor, other.Anchor) && Intersectioned.Equals(other.Intersectioned);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Anchor != null ? Anchor.GetHashCode() : 0)*397) ^ Intersectioned.GetHashCode();
            }
        }

        public TracePanel Anchor { get; set; }
        public bool Intersectioned { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AnchorEntity) obj);
        }
    }
}
