/* global moment*/
financialPlannerApp.factory('timesAndDatesService', function (moment) {
    let standardTimezone = "Europe/London";
    return {
        getDisplayDateFromIsoOffset(dateTimeOffsetString){
                const date = moment(dateTimeOffsetString).format("DD/MM/YYYY");
                return date;
        },
        getDisplayTimeFromIsoOffset(dateTimeOffsetString){
            const time = moment(dateTimeOffsetString).format("HH:mm:ss");
            return time;
        },
        getDateInStandardTimezone(date){
            return moment(date).tz(standardTimezone);
        }
    }
    
});