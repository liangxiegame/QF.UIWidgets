using System.Runtime.InteropServices.WindowsRuntime;
using Unity.UIWidgets;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace QFramework.UIWidgets
{
    public class ContainerBuilder
    {
        private Widget mChild { get; set; }
        private Alignment mAlignment { get; set; }
        
        private Color mColor { get; set; }

        private float? mWidth = null;
        private float? mHeight = null;
        
        
        private EdgeInsets mMargin { get; set; } = EdgeInsets.zero;
        private EdgeInsets mPadding { get; set; } = EdgeInsets.zero;
        
        public static ContainerBuilder GetBuilder()
        {
            return new ContainerBuilder();
        }

        public ContainerBuilder Child(Widget child)
        {
            mChild = child;
            return this;
        }

        public ContainerBuilder Color(Color color)
        {
            mColor = color;
            return this;
        }

        private Color mBorderColor = null;

        public ContainerBuilder BorderColor(Color color)
        {
            mBorderColor = color;
            return this;
        }

        public ContainerBuilder Width(float width)
        {
            mWidth = width;
            return this;
        }

        public ContainerBuilder Height(float height)
        {
            mHeight = height;
            return this;
        }

        public ContainerBuilder MarginLeftRight(float left = 0, float right = 0)
        {
            mMargin = EdgeInsets.only(left: left, right: right, top: mMargin.top, bottom: mMargin.bottom);
            return this;
        }

        public ContainerBuilder MarginTop(float top)
        {
            mMargin = EdgeInsets.only(top: top, right: mMargin.right, left: mMargin.left, bottom: mMargin.bottom);
            return this;
        }

        public ContainerBuilder MarginAll(int distance)
        {
            mMargin = EdgeInsets.all(distance);
            return this;
        }

        public ContainerBuilder PaddingAll(int distance)
        {
            mPadding = EdgeInsets.all(distance);
            return this;
        }

        public ContainerBuilder AlignmentCenter()
        {
            mAlignment = Alignment.center;
            return this;
        }
        
        public ContainerBuilder AlignmentTopCenter()
        {
            mAlignment = Alignment.topCenter;
            return this;
        }

        private Decoration mDecoration = null;
        private BoxConstraints mConstraints = null;
        private Matrix3 mTransform = null;
        
        public ContainerBuilder Decoration(Decoration decoration)
        {
            mDecoration = decoration;
            return this;
        }
        
        public ContainerBuilder Constraints(BoxConstraints constraints)
        {
            mConstraints = constraints;
            return this;
        }
        
        public ContainerBuilder Transform(Matrix3 transform)
        {
            mTransform = transform;
            return this;
        }

        public Container EndContainer()
        {
            return new Container(
                child: mChild,
                alignment: mAlignment,
                color: mColor,
                width: mWidth,
                height: mHeight,
                margin: mMargin,
                padding: mPadding,
                transfrom: mTransform,
                constraints: mConstraints,
                decoration: mDecoration);
        }
    }
}