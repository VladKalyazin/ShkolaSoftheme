using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace SortGraphics
{
    public class GraphicViewModel
    {
        public PlotModel Model { get; set; }

        public GraphicViewModel(Dictionary<string, Action<List<int>>> sortings)
        {
            Model = new PlotModel();
            Model.Title = "Sortings efficiency";

            var _PointGraphics = SortingsTester.GetTestAnalysis(sortings);

            foreach (var data in _PointGraphics)
            {
                var graph = new LineSeries();
                foreach (var point in data.Value)
                    graph.Points.Add(point);
                graph.Title = data.Key;
                graph.Font = "Arial";
                graph.FontSize = 16;
                Model.Series.Add(graph);
            }

            Model.LegendPlacement = LegendPlacement.Outside;
        }

    }
}
