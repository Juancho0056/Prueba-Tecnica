export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Puntos Ophelia',
    icon: 'folder',
    items: [
      {
        text: 'Articulos',
        path: '/articulo/list'
      },
      {
        text: 'Clientes',
        path: '/cliente/list'
      },
      {
        text: 'Facturas',
        path: '/factura/list'
      }
    ]
  }
];
