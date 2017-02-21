using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLib.App.ViewModel
{
    public class TableViewModel
    {
        public class Cell1
        {
            public string ButtonText { get; set; }

            public NewsModel NewsItem { get; set; }

            public Cell1()
            {
                NewsItem = new NewsModel { Title = "News 1", NewsURL = "URL 1" };
                ButtonText = "Press Me!";
            }
        }

        public class Cell2
        {
            public NewsModel NewsItem { get; set; }

            public Cell2()
            {
                NewsItem = new NewsModel { Title = "News 2", NewsURL = "URL 2" };
            }
        }

        public string EntryCellLabel { get; set; }

        public string TextCellText { get; set; }

        public Cell1 FirstCell { get; set; }

        public Cell2 SecondCell { get; set; }

        public TableViewModel()
        {
            EntryCellLabel = "Label 1";
            TextCellText = "Text 1";
            FirstCell = new Cell1();
            SecondCell = new Cell2();
        }


    }
    public class NewsModel
    {
        public string Title { get; set; }
        public string NewsURL { get; set; }
        public string MainImageURL { get; set; }
    }
}
