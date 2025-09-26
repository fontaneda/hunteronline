const close = document.getElementById('close');
const settings = document.getElementById('settings_btn');
//const settings = document.getElementsByName('<%=settings_btn.UniqueID%>');
//const settings = document.getElementById ('<%=fileName.ClientID%>');

function changeState() {
    const message = document.querySelector('.messages');
    message.classList.add('close-message');
    setTimeout(() => {
        message.style.display = 'none';
    }, 300);


}

function openMenu() {
//alert('abrir2')
    document.getElementById('menu_settings').classList.toggle('show-menu-settings');
    
}


if (settings) {
//alert('abrir1')
    settings.addEventListener('click', openMenu);
}


if (close) {
    close.addEventListener('click', changeState);
}
//