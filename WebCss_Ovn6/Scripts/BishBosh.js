var bishBosh = function () {

    var valueBish = getTxtBoxValue('txtBish');
    var valueBosh = getTxtBoxValue('txtBosh');
    var valueNumIterations = getTxtBoxValue('txtNumIterations');

    if (valueBish === null || !isNumber(valueBish)) {
        alert('Bish Value not a number');
        return;
    }

    if (valueBosh === null || !isNumber(valueBosh)) {
        alert('Bosh Value not a number');
        return;
    }

    if (valueNumIterations === null || !isNumber(valueNumIterations)) {
        alert('iterations is not a number');
        return;
    }

    var rows = bishBoshExecute(valueNumIterations, valueBish, valueBosh);

    showResults(rows);
}

var isNumber = function (value) {
    if (isNaN(value)) {
        return false;
    }
    return true;
}

var getTxtBoxValue = function (id) {
    var txtBox = document.getElementById(id);
    if (txtBox !== null && txtBox.type === 'text') {
        return txtBox.value;
    }
    return null;
}

var showResults = function (rows) {

    var txtOutput = document.getElementById('resOutput');

    if (txtOutput === null || rows === null) {
        return;
    }

    var res = '';
    for (var i = 0; i < rows.length; i++) {
        res += rows[i] + '<br>'
    }
    txtOutput.innerHTML = res;
}

var bishBoshExecute = function (iterations, numBish, numBosh) {
    console.debug('Start: BishBosh.js');

    var result = new Array();

    for (var i = 1; i <= iterations; i++) {

        var isBish = false;
        var isBosh = false;

        if (i % numBish === 0) isBish = true;
        if (i % numBosh === 0) isBosh = true;

        if (isBish && isBosh) {
            console.debug('Bish-Bosh');
            result[i] = 'Bish-Bosh';
            continue;
        }
        else if (isBish) {
            console.debug('Bish');
            result[i] = 'Bish';
            continue;
        }
        else if (isBosh) {
            console.debug('Bosh');
            result[i] = 'Bosh';
            continue;
        }
        result[i] = i;
        console.debug(i);
    }
    return result;
}