var udateTime = function () {
    let currentDate = new Date(),
        hours = currentDate.getHours(),
        minutes = currentDate.getMinutes(),
        seconds = currentDate.getSeconds()
        
    try {
        document.getElementById('hours').textContent = hours;
    } catch (err) {
        //console.log("**");
    }
        

    if (minutes < 10) {
        minutes = "0" + minutes
    }

    if (seconds < 10) {
        seconds = "0" + seconds
    }
    try {
        document.getElementById('minutes').textContent = minutes;
    } catch (err) {
    }
        
    //document.getElementById('seconds').textContent = seconds;
};
    
udateTime();

setInterval(udateTime, 1000);
    
    