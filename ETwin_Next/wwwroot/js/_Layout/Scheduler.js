    //#region BIND SCHEDULER
function bindScheduler(lstAppointments, lstResources, schedulersettings) {
    //debugger;
    const startDayHour = 8;
    const endDayHour = 20;

    const appointments = [];
    $.each(lstAppointments, function (index, appointmentData) {
        var appointment = {
            text: appointmentData.Description,
            startDate: new Date(appointmentData.StartAppointment),
            endDate: new Date(appointmentData.EndAppointment),
            fieldExpr: appointmentData.ResourceID
        };
        appointments.push(appointment);
    });


    const risorse = [];
    $.each(lstResources, function (index, resourceData) {
        var resource = {
            fieldExpr: resourceData.ResourceId,
            label: resourceData.Caption
        };
        risorse.push(resource);
    });

    $('#schedulerContainer').dxScheduler({
        height: 670,
        // adaptivityEnabled: true,
        groups: ['ResourceId'],
        dataSource: appointments,
        views: ['day', 'week', 'workWeek', 'month'],
        currentView: 'workWeek',
        currentDate: new Date(),
        startDayHour: 9,

        resources: risorse,

    });
}
//#endregion