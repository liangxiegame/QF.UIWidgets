
namespace QFramework.UIWidgets
{
    public partial class QF
    {
        public static ContainerBuilder Container => new ContainerBuilder();

        public static TextBuilder Text => new TextBuilder();

        public static TextSpanBuilder TextSpan => new TextSpanBuilder();

        
        public static ListViewBuilder ListView => new ListViewBuilder();
        
        public static EditableTextBuilder EditableText => new EditableTextBuilder();
        
        
        public static ColumnBuilder Column => new ColumnBuilder();
        public static RowBuilder Row => new RowBuilder();
        public static FlexBuilder Flex => new FlexBuilder();
        public static TextStyleBuilder TextStyle => new TextStyleBuilder();
        
        public static RaisedButtonBuilder RaisedButton => new RaisedButtonBuilder();
        public static OutlineButtonBuilder OutlineButton => new OutlineButtonBuilder();
        public static FlatButtonBuilder FlatButton => new FlatButtonBuilder();
        public static IconButtonBuilder IconButton => new IconButtonBuilder();
    }
}