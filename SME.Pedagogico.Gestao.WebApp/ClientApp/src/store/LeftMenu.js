export const types = {
    LEFT_MENU_TOGGLE: "LEFT_MENU_TOGGLE",
    SELECT_MENU_ITEM: "SELECT_MENU_ITEM",
    SELECT_MENU_SUB_ITEM: "SELECT_MENU_SUB_ITEM",
    RESET_MENU_STATE: "RESET_MENU_STATE",
}
const initialState = {
    leftMenuIsOpen: false,
    menuItems: [
        {
            icon: "fas fa-calendar-check left-menu-item-icon",
            name: "Registro de Classe",
            selected: false,
            subitems: [
                { selected: false, name: "Plano de Aula", link: "/RegistroDeClasse/PlanoDeAula" },
                { selected: false, name: "Plano Anual", link: "/RegistroDeClasse/PlanoAnual" },
                { selected: false, name: "Plano de Ciclo", link: "/RegistroDeClasse/PlanoDeCiclo" },
                { selected: false, name: "Sondagem", link: "/RegistroDeClasse/Sondagem" },
                { selected: false, name: "Documentos", link: "/RegistroDeClasse/Documentos" },
            ]
        },
        {
            icon: "fas fa-file-signature left-menu-item-icon",
            name: "Relatórios",
            selected: false,
            subitems: [
                { selected: false, name: "Plano de Aula", link: "/RegistroDeClasse/PlanoDeAula" },
                { selected: false, name: "Plano Anual", link: "/RegistroDeClasse/PlanoAnual" },
                { selected: false, name: "Plano de Ciclo", link: "/RegistroDeClasse/PlanoDeCiclo" },
                { selected: false, name: "Sondagem", link: "/RegistroDeClasse/Sondagem" },
                { selected: false, name: "Documentos", link: "/RegistroDeClasse/Documentos" },
            ]
        },
        {
            icon: "fas fa-cog left-menu-item-icon",
            name: "Administração",
            selected: false,
            subitems: [
                { selected: false, name: "Área Administrativa", link: "/Admin" },
            ]
        },
    ],
    breadcrumb: [{ page: "Home", link: "/" }],
};

export const actionCreators = {
    openMenu: () => ({ type: types.LEFT_MENU_TOGGLE }),
    selectMenuItem: (name) => ({ type: types.SELECT_MENU_ITEM, name }),
    selectMenuSubItem: (menuItemName, name) => ({ type: types.SELECT_MENU_SUB_ITEM, menuItemName, name }),
    resetMenuState: () => ({ type: types.RESET_MENU_STATE }),
};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case types.LEFT_MENU_TOGGLE:
            return ({
                ...state,
                leftMenuIsOpen: !state.leftMenuIsOpen
            });
        case types.SELECT_MENU_ITEM:
            var modifiedMenuItems = [...state.menuItems];

            for (var i = 0; i < modifiedMenuItems.length; i++)
                if (modifiedMenuItems[i].name === action.name)
                    modifiedMenuItems[i].selected = !modifiedMenuItems[i].selected;
                else
                    modifiedMenuItems[i].selected = false;

            return ({
                ...state,
                menuItems: modifiedMenuItems
            });
        case types.SELECT_MENU_SUB_ITEM:
            var modifiedMenuSubItems = [...state.menuItems];
            var breadcrumb = [{ page: "Home", link: "/" }];

            for (var index = 0; index < modifiedMenuSubItems.length; index++)
                if (modifiedMenuSubItems[index].name === action.menuItemName) {
                    breadcrumb.push({ page: action.menuItemName, link: null });

                    for (var j = 0; j < modifiedMenuSubItems[index].subitems.length; j++) {
                        if (modifiedMenuSubItems[index].subitems[j].name === action.name) {
                            modifiedMenuSubItems[index].subitems[j].selected = true;
                            breadcrumb.push({ page: action.name, link: modifiedMenuSubItems[index].subitems[j].link });
                        }
                        else
                            modifiedMenuSubItems[index].subitems[j].selected = false;
                    }
                }
                else
                    for (var k = 0; k < modifiedMenuSubItems[index].subitems.length; k++)
                        modifiedMenuSubItems[index].subitems[k].selected = false;

            return ({
                ...state,
                menuItems: modifiedMenuSubItems,
                breadcrumb: breadcrumb
            });
        case types.RESET_MENU_STATE:
            var resetMenuItems = [...state.menuItems];

            for (var l = 0; l < resetMenuItems.length; l++) {
                resetMenuItems[l].selected = false;

                for (var m = 0; m < resetMenuItems[l].subitems.length; m++)
                    resetMenuItems[l].subitems[m].selected = false;
            }

            return ({
                ...state,
                menuItems: resetMenuItems,
                breadcrumb: [{ page: "Home", link: "/" }],
            })
        default:
            return (state);
    }
};
