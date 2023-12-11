function gridSetup(response) {
    var index = 0;

    var gridColumns = [];
    var columns = [];
    var treeList = response.lstDepartment.treeList;
    allowDragDrop = response.lstDepartment.allowDragDrop;
    $.each(response.lstDepartment.gridBands, function (value, key) {

        var captions = {
            caption: key.caption,
            idGrid: key.idGrid,
            columns: columns,
            headerCellTemplate: function (header, info) {
                $('<div>')
                    .html(info.column.caption)
                    .appendTo(header);
                // header.parent().css("backgroundColor", '#FFA500');
                header.parent().css("foreColor", '#aaa');
                header.parent().css("fontName", key.fontName);
                header.parent().css("fontSize", key.fontSize);
            }
        }
        var index = 0;
        captions.columns = [];
        //debugger;

        $.each(key.gridsColumns, function (value, key) {
            var columns = {
                caption: key.columnText,
                visible: true,
                query: key.queryTypeCombo,
                dataField: key.columnName.charAt(0).toLowerCase() + key.columnName.slice(1),
                columnType: key.idColumnType,
                functionName: key.functionName,
                headerCellTemplate: function (header, info) {
                    $('<div>')
                        .html(info.column.caption)
                        .appendTo(header);
                    header.parent().css("backgroundColor", key.backColor);
                    header.parent().css("foreColor", key.foreColor);
                    header.parent().css("fontName", key.fontName);
                    header.parent().css("fontSize", key.fontSize);
                }
            }
            if (index < 3) {
                captions.columns.push(columns);
                index++;
            }
            else {
                columns.visible = false;
                captions.columns.push(columns);
            }
        })
        gridColumns.push(captions);
    });
    if (treeList == false) {
        bindGrid(gridColumns, response.lstDepartment.data, response.jsonCombo)
    }
    else {
        bindTreeList(gridColumns, response.lstDepartment.data,);
    }
}

//#region BIND GRID
function bindGrid(gridColumns, gridData, jsonCombo) {
    $(() => {
        grid = $('#gridContainer').dxDataGrid({
            dataSource: {
                store: {
                    type: 'array',
                    data: gridData,
                }
            },
            //I save the customizations in the session
            stateStoring: {
                enabled: true,
                type: "localStorage",
            },
            //Popup for row customization
            editing: {
                mode: 'popup',
                popup: {
                    position: {
                        my: 'top',
                        at: 'top',
                        of: '#gridContainer',
                    },
                    showTitle: true,

                },
                texts: {
                    confirmDeleteMessage: 'Vuoi cancellare davvero?',
                },
            },
            selection: {
                mode: 'multiple',
            },
            //When I select a row I change the AddRow button
            onSelectionChanged(e) {
                //debugger;
                selectedRowIndex = e.component.getRowIndexByKey(e.selectedRowKeys[0]);
                editSDA.option('visible', selectedRowIndex !== -1);
            },
            //Management of moving lines and new priorities
            rowDragging: {
                allowReordering: allowDragDrop,
                showDragIcons: false,
                onDragStart: function (e) {
                    const selectedData = e.component.getSelectedRowsData();
                    e.itemData = getVisibleRowValues(selectedData, e.component);
                },
                dragTemplate: function (dragData) {
                    const itemsContainer = $("<table>").addClass("drag-container");
                    dragData.itemData.forEach(rowData => {
                        const itemContainer = $("<tr>");
                        for (const field in rowData) {
                            itemContainer.append($("<td>").text(rowData[field]));
                        }
                        itemsContainer.append(itemContainer);
                    });
                    return $("<div>").append(itemsContainer);
                },

                onReorder: function (e) {
                    //debugger;
                    var dataGrid = e.component,
                        selectedRows = dataGrid.getSelectedRowsData(),
                        toIndex = e.toIndex,
                        fromIndex = e.fromIndex;

                    for (var i = 0; i < selectedRows.length; i++) {
                        fromIndex = gridData.findIndex(item => item === selectedRows[i]);
                        gridData.splice(fromIndex, 1);
                        gridData.splice(toIndex, 0, selectedRows[i]);
                    }
                    //debugger;
                    setRank(gridData, gridColumns[0].idGrid, dataGrid);
                    dataGrid.refresh();
                },




            },

            paging: {
                enable: false,
            },

            onRowUpdating: function (e) {
                $.ajax({
                    url: "/DataGrid/GetGridNameById",
                    data: { "idGrid": gridColumns[0].idGrid },
                    success: function (response) {
                        $.ajax({
                            url: "/DataGrid/EditRow",
                            method: "POST",
                            data: JSON.stringify({ "newData": e.newData, "gridName": response, "oldData": e.oldData }),
                            contentType: "application/json",
                        });
                    },
                });


            },
            // onRowInserted
            onRowInserting: function (e) {
                $.ajax({
                    url: "/DataGrid/GetGridNameById",
                    data: { "idGrid": gridColumns[0].idGrid },
                    success: function (response) {
                        $.ajax({
                            url: "/DataGrid/AddRow",
                            method: "POST",
                            data: JSON.stringify({ "row": e.data, "gridName": response }),
                            contentType: "application/json",
                        });
                    },
                });
                grid.refresh();
            },
            onRowRemoved: function (e) {
                // $.ajax({
                //     url: "/DataGrid/DeleteRow",
                //     method: "POST",
                //     data: JSON.stringify({ "row": e.data, "gridName": gridColumns[0].caption }),
                //     contentType: "application/json",
                // });
            },
            columnHidingEnabled: true,
            allowColumnReordering: true,
            allowColumnResizing: true,
            columnAutoWidth: true,
            showBorders: true,
            headerFilter: {
                visible: true,
            },
            remoteOperations: true,
            scrolling: {
                mode: 'virtual',
            },
            sorting: {
                mode: 'none',
            },
            columnChooser: {
                enabled: true,
                position: {
                    my: 'right top',
                    at: 'right bottom',
                    of: '.dx-datagrid-column-chooser-button',
                },
            },

            columnFixing: {
                enabled: true,
            },
            columns: gridColumns,
            searchPanel: {
                visible: true,
                width: 240,
                placeholder: 'Search...',
            },
            allowEditing: true,
            rowAlternationEnabled: true,
            showRowLines: false,
            showBorders: false,
            customizeColumns: function (columns, options) {
                // Create columns dynamically based on dynamic object properties
                for (var i = 0; i < columns.length; i++) {
                    let column = columns[i];
                    if (!column.isBand) {
                        var columnName = column.name.toLowerCase();
                        column.dataField = columnName;
                        var colType = column.columnType;
                        console.log("COLONNA IN ANALISI : " + column.dataField);
                        switch (colType) {
                            case 1:
                                //ALPHANUMERIC
                                break;
                            case 2:
                                //DATE
                                break;
                            case 3:
                                //TIME
                                break;
                            case 4:
                                //INT
                                break;
                            case 5:
                                //FLOAT
                                break;
                            case 6:
                                //CURRENCY
                                break;
                            case 7:
                                for (var element of jsonCombo) {
                                    var keys = Object.keys(element);
                                    if (column.dataField === keys[0]) {
                                        var chiave = keys[0];
                                        var valore = element[chiave];
                                        console.log("CHIAVE: " + chiave);
                                        console.log("VALORE : " + valore);

                                        const jsonParse = JSON.parse(valore);
                                        column.lookup = {
                                            dataSource: jsonParse,
                                            displayExpr: "valore",
                                            valueExpr: "id"
                                        };
                                    }
                                }

                                break;
                            case 8:
                                //OPEN FILE
                                break;
                            case 9:
                                //OPEN DIRECTORY
                                break;
                            case 10:
                                //IMAGE
                                //Replace the cell value with an image
                                column.cellTemplate = function (container, options) {
                                    var cellValue = "";
                                    if (options == "undefined") {
                                        cellValue = options;
                                    }
                                    else {
                                        cellValue = options.data[options.column.dataField];
                                    }
                                    var percorsoImmagine = "../images/" + cellValue + ".png";

                                    var img = new Image();
                                    img.src = percorsoImmagine;

                                    img.onload = function () {
                                        $("<img>")
                                            .attr("src", "../images/" + cellValue + ".png")
                                            .attr("width", 15)
                                            .attr("height", 15)
                                            .attr("padding", 0)
                                            .attr("margin", 0)
                                            .appendTo(container);
                                    };

                                };
                                break;
                            case 11:
                                //CALCULATE
                                break;
                            case 12:
                                //STATE
                                break;
                            case 13:
                                //PERCENTAGE
                                break;
                            case 14:
                                //LOOK UP EDIT
                                break;
                            case 15:
                                //DATETIME
                                break;
                            case 16:
                                //GENERATE REPORT
                                //Open the report of the selected process
                                column.cellTemplate = function (container, options) {
                                    var button = $("<button>")
                                        .appendTo(container);

                                    $("<i>")
                                        .addClass("fas fa-file-pdf")
                                        .appendTo(button);

                                    button.on("click", function () {

                                        $.ajax({
                                            url: "/Drawing/CreateDrawing",
                                            data: { "iddisegno": options.data.iddisegno },
                                            success: function (response) {
                                                if (response != null) {
                                                    var valore = response;
                                                    var nuovaFinestra = window.open(response, '_blank');
                                                    nuovaFinestra.addEventListener('unload', function (event) {
                                                        $.ajax({
                                                            url: "/Drawing/DeleteFile",
                                                            data: { "path": valore },
                                                        });
                                                    });
                                                }
                                            }
                                        });
                                    });
                                };

                                break;
                            case 17:
                                //When it is a button type I open the function that is passed as a value
                                var fnName = column.functionName;
                                column.cellTemplate = function (container, options) {
                                    $("<button>")
                                        .addClass("btn btn-primary")
                                        .text("Bottone")
                                        .on("click", function () {
                                            window[fnName]()
                                        })
                                        .appendTo(container);
                                };
                                break;
                        }
                    }
                }
            },
            //I enable export and decide the file types
            export: {
                enabled: true,
                allowExportSelectedData: false,
                formats: ['xlsx', 'pdf'],
            },
            onExporting(e) {
                // debugger;
                if (e.format === 'xlsx') {
                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet('Grid');
                    DevExpress.excelExporter.exportDataGrid({
                        component: e.component,
                        worksheet,
                        autoFilterEnabled: false,

                    }).then(() => {
                        workbook.xlsx.writeBuffer().then((buffer) => {
                            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Grid.xlsx');
                        });
                    });
                }
                else if (e.format === 'pdf') {
                    window.jsPDF = window.jspdf.jsPDF
                    const doc = new jsPDF();
                    //debugger;
                    DevExpress.pdfExporter.exportDataGrid({
                        jsPDFDocument: doc,
                        component: e.component,
                        indent: 5,
                    }).then(() => {
                        doc.save('Grid.pdf');
                    });
                }
            },
        }).dxDataGrid('instance')
    })
}
//#endregion

//#region TREE LIST

function bindTreeList(gridColumns, data) {
    $(() => {
        $('#gridContainer').dxTreeList({
            dataSource: data,
            //I decide the master key
            keyExpr: 'id',
            //I set the parent key
            parentIdExpr: 'idparent',
            columnAutoWidth: true,
            wordWrapEnabled: true,
            showBorders: true,
            searchPanel: {
                visible: true,
                width: 250,
            },
            headerFilter: {
                visible: true,
            },
            columnChooser: {
                enabled: true,
                position: {
                    my: 'right top',
                    at: 'right bottom',
                    of: '.dx-treelist-column-chooser-button',
                },
            },
            columns: gridColumns,
            customizeColumns: function (columns, options) {
                for (var i = 0; i < columns.length; i++) {
                    let column = columns[i];
                    if (!column.isBand) {
                        var columnName = column.name.toLowerCase();
                        // debugger;
                        column.dataField = columnName;
                        var colType = column.columnType;
                        console.log("COLONNA IN ANALISI : " + column.dataField);

                        switch (colType) {
                            case 7:
                                //debugger;
                                for (var element of jsonCombo) {
                                    var keys = Object.keys(element);
                                    if (column.dataField === keys[0]) {
                                        var chiave = keys[0];
                                        var valore = element[chiave];
                                        console.log("CHIAVE: " + chiave);
                                        console.log("VALORE : " + valore);

                                        const jsonParse = JSON.parse(valore);
                                        column.lookup = {
                                            dataSource: jsonParse,
                                            displayExpr: "valore",
                                            valueExpr: "id"
                                        };
                                    }
                                }

                                break;

                            case 17:
                                var fnName = column.functionName;
                                //debugger
                                column.cellTemplate = function (container, options) {
                                    // var cellValue = options.data[options.column.dataField];
                                    $("<button>")
                                        .addClass("btn btn-primary")
                                        .text("Bottone")
                                        .on("click", function () {
                                            window[fnName]()
                                        })
                                        .appendTo(container);
                                };
                                break;
                            case 10:
                                column.cellTemplate = function (container, options) {
                                    var cellValue = options.data[options.column.dataField];
                                    var percorsoImmagine = "../images/" + cellValue + ".png"; // Sostituisci con il percorso relativo all'immagine

                                    var img = new Image();
                                    img.src = percorsoImmagine;

                                    img.onload = function () {
                                        $("<img>")
                                            .attr("src", "../images/" + cellValue + ".png")
                                            .attr("width", 15)
                                            .attr("height", 15)
                                            .attr("padding", 0)
                                            .attr("margin", 0)
                                            .appendTo(container);
                                    };

                                };
                                break;
                            case 16:
                                column.cellTemplate = function (container, options) {
                                    var button = $("<button>")
                                        .appendTo(container);

                                    $("<i>")
                                        .addClass("fas fa-file-pdf")
                                        .appendTo(button);

                                    button.on("click", function () {
                                        fetch(options.data.fullpathetwin)
                                            .then(response => {
                                                if (!response.ok) {
                                                    throw new Error('Errore nella risposta del server: ' + response.status + ' ' + response.statusText);
                                                }
                                                return response.blob();
                                            })
                                            .then(blob => {
                                                const url = URL.createObjectURL(blob);
                                                const a = document.createElement('a');
                                                a.href = url;
                                                a.download = 'nome_del_file';
                                                document.body.appendChild(a);
                                                a.click();
                                                document.body.removeChild(a);
                                            })
                                            .catch(error => {
                                                console.error('Errore durante il download del file:', error.message);
                                            });
                                    });
                                };

                                break;
                        }
                    }
                }
            },
        });
    });
}
//#endregion

function setRank(gridData, idGrid, dataGrid) {
    //I update priorities when rows are moved
    $.ajax({
        url: "/DataGrid/GetGridNameById",
        data: { "idGrid": idGrid },
        success: function (response) {
            for (var i = 0; i < gridData.length; i++) {
                if (gridData[i].rank !== i + 1) {
                    //debugger;
                    $.ajax({
                        url: "/DataGrid/EditRow",
                        method: "POST",
                        data: JSON.stringify({ "newData": { "rank": i + 1 }, "gridName": response, "oldData": { "IdOrderRow": gridData[i].rowid } }),
                        contentType: "application/json",
                    });
                    gridData[i].rank = i + 1;
                    dataGrid.refresh();
                }
            }
        },
    });
}

function calculateToIndex(dataArray, e) {
    const visibleRows = e.component.getVisibleRows();
    const toIndex = dataArray.findIndex((item) => item === visibleRows[e.toIndex].data);
    return e.fromIndex >= e.toIndex ? toIndex : toIndex + 1;
}
function getVisibleRowValues(rowsData, grid) {
    const visbileColumns = grid.getVisibleColumns();
    const selectedData = rowsData.map(rowData => {
        const visibleValues = {};
        visbileColumns.forEach(column => {
            visibleValues[column.dataField] = getVisibleCellValue(column, rowData);
        });
        return visibleValues;
    });
    return selectedData;
}
function getVisibleCellValue(column, rowData) {
    const cellValue = rowData[column.dataField];
    return column.lookup ? column.lookup.calculateCellValue(cellValue) : cellValue;
}
function shouldClearSelection() {
    return $("#clearAfterDropSwitch").dxSwitch("option", "value");
}