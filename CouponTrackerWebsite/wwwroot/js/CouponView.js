//page is loaded
document.addEventListener('DOMContentLoaded', (event) => {
    document.getElementsByClassName('form-control')[0].addEventListener("change", submitAction)
})

function submitAction() {
    document.getElementsByClassName('btn btn-primary')[0].click();
}