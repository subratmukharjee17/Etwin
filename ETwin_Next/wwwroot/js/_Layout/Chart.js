var seriesItems = [];
function selectChart(dataSource, response) {
    // Iterate through dataSource
    $.each(dataSource, function (value, key) {
        var item = { valueField: "valueDataMember", name: key.seriesName };
        key.argumentDataMember = key.argumentDataMember.replace("T00:00:00", "");

        // Check if the series already exists in series
        if (series.length === 0 || jQuery.inArray(key.seriesName, series) === -1) {
            series.push(key.seriesName);
            seriesItems.push(item);
        }
        else {
            if (jQuery.inArray(key.seriesName, series) == -1) {
                series.push(key.seriesName);
                seriesItems.push(item);
            }
        }
    });
    bindChart(response.chartname, seriesItems, dataSource);
};


function bindChart(title, serie, chartData) {
    $(() => {
        const chart = $('#chartContainer').dxChart({
            palette: 'Harmony Light',
            title: title,
            dataSource,
            commonSeriesSettings: {
                argumentField: 'argumentDataMember',
                valueField: 'valueDataMember',
                type: types[0], //"area",  //fullstackedarea   //area
            },
            seriesTemplate: {
                nameField: 'seriesName',
            },
            argumentAxis: {
                valueMarginsEnabled: false,
            },
            margin: {
                bottom: 10,
            },
            series: {},
            export: {
                enabled: true,
            },
            legend: {
                verticalAlignment: 'bottom',
                horizontalAlignment: 'center',
            },
        }).dxChart('instance');
        $('#rangeSelector').dxRangeSelector({
            dataSource: chartData,
            chart: {
                series: [{
                    name: 'seriesName',
                    argumentField: 'argumentDataMember',
                    valueField: 'valueDataMember',
                    type: types[0], //"area",  //fullstackedarea   //area
                }],
            },

            behavior: {
                valueChangeMode: 'onHandleMove',
                snapToTicks: false,
            },
            onValueChanged(e) {
                const zoomedChart = $('#chartContainer').dxChart('instance');
                zoomedChart.getArgumentAxis().visualRange(e.value);
            },
        });

    });
}