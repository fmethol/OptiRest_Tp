const queryString = window.location.search;
console.log(queryString);
const urlParams = new URLSearchParams(queryString);
const tenantId = urlParams.get('tenantId')

async function getMenu() {
    let url = 'https://localhost:44325/api/Menu/' + tenantId;
    //let url = 'https://localhost:44325/api/Menu/2';
    try {
        let res = await fetch(url);
        return await res.json();
    } catch (error) {
        console.log(error);
    }
}

async function renderMenu() {
    let menu = await getMenu();
    let titulo = menu.restaurant.businessConfig.displayName;
    let slogan = menu.restaurant.businessConfig.slogan;
    let summary = menu.restaurant.businessConfig.summary;
    let logo = menu.restaurant.businessConfig.logo;
    let categories = menu.categories;
    let imgLogo = '<img src="data:image/jpeg;base64,' + logo + '" height=180;>';
    
    let htmlmenu = '';
  
    categories.forEach(category => {
        let htmlSegment = `<h3 class="titcat mt-4 mb-2" >${category.name}</h3>`;
        htmlSegment += `<ul class="list-group">`;
        category.items.forEach(item => {
            htmlSegment += `<li class="list-group-item">
                                <div>
                                    <div class="cont_tit_cant">
                                        <div class="cartilla-item__name">
                                            ${item.title}
                                        </div>
                                        <div class="btns">
                                            <p class="cartilla-item__price">${item.price.toLocaleString('es-AR', { style: 'currency', currency: 'ARS' })}</p>
                                        </div>
                                    </div>
                                    <div class="cont_tit_cant">
                                        <div class="cartilla-item__summary">
                                            ${item.summary}
                                        </div>
                                    </div>
                                </div>       
                            </li>`;
        });

        htmlmenu += htmlSegment;
    });

    document.querySelector('.titulo').innerHTML = titulo;
    document.querySelector('.slogan').innerHTML = slogan;
    document.querySelector('.summary').innerHTML = summary;
    document.querySelector('.logo').innerHTML = imgLogo;
    document.querySelector('.menu').innerHTML = htmlmenu;

}

renderMenu();