const inputs = [];

export function init(element, options) {
    const iii = window.intlIdInput(element, options);
    inputs.push(iii);
    return inputs.indexOf(iii);
}

export function get(id) {
    const input = inputs[id];

    const number = input.getNumber();
    const isValid = input.isValid();
    const countryData = input.getSelectedCountryData();

    return { isValid, number, countryData };
}

export function setNumber(id, number) {
    const input = inputs[id];
    input.setNumber(number);
}