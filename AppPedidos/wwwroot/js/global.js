document.addEventListener('click', function (event) {

    const btnSeta = document.getElementById('btn_seta');
    const submenuUser = document.getElementById('sub-menu-user');

    const ClickInsideMenu = btnSeta.contains(event.target) || submenuUser.contains(event.target);

    if (ClickInsideMenu) {
        if (submenuUser.style.display === 'none' || submenuUser.style.display === '') {
            submenuUser.style.display = 'flex';
        } else {
            submenuUser.style.display = 'none';
        }
    } else {
        submenuUser.style.display = 'none';
    }
});

//código da sidebar
document.addEventListener('DOMContentLoaded', function () {
    const sidebar = document.getElementById('main-sidebar');
    const imgLogo = document.getElementById('img-logo');
    const navBarImage = document.getElementById('image_logo');
    const tooggleButton = document.getElementById('toggle_button')
    let smallScreen = window.innerWidth < 900;

    function toggleSidebar() {
        if (smallScreen) {

            if (sidebar.classList.contains('open')) {
                sidebar.classList.add('hidden');
                setTimeout(() => {
                    sidebar.classList.remove('open')
                }, 300);
            } else {
                sidebar.classList.remove('hidden');
                sidebar.classList.add('open');
            }
        } else {
            sidebar.classList.toggle('sidebar-collapsed');
            imgLogo.classList.toggle('img-logo-collapsed');

            if (sidebar.classList.contains('sidebar-collapsed')) {
                navBarImage.src = '/img/Logo_site_mini.jpg';
            } else {

                navBarImage.src = '/img/Logo_site.jpg';
            }
        }
    }


    window.addEventListener('resize', function () {
        smallScreen = this.window.innerWidth < 900;
        if (smallScreen) {
            sidebar.classList.remove('sidebar-collapsed');
            imgLogo.classList.remove('img-logo-collapsed');
            sidebar.classList.add('hidden');
            navBarImage.src = '/img/Logo_site.jpg';
        } else {
            sidebar.classList.remove('open', 'hidden');
        }

    });
    tooggleButton.addEventListener('click', toggleSidebar);

});
