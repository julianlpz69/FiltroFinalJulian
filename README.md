# FiltroFinalJulian

<br><br>

###  Devuelve un listado de todos los pagos que se realizaron en el año 2008 mediante paypal ordene el resultado de menor a mayor

Ruta : http://localhost:5283/api/pago/2008paypal

![Captura de pantalla 2023-11-23 161247](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/14dbb76d-9164-4c6e-a67e-47825291f6b3)

<br>

Explicacion : Con el where filtro los pago con año en su fecha igual a 2008 y que la forma de pago que es un string sea Paypal y los ordeno decendentemente por el valor total

<br><br>

###  Devuelve un listado de las formas de pago que aparecen en la tabla pago sin repetirse

Ruta : http://localhost:5283/api/pago/FormasPago

![Captura de pantalla 2023-11-23 162322](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/ea7309ce-30c0-4c61-ac1f-4911f4041fd9)

<br>

Explicacion : Seleccion el nombre de la forma de pago de todos los pagos y con el metodo Distinct les digo que no se repitan 

<br><br>

###  Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus represententas junto con la ciudad de la oficina a la que pertenece el representante

Ruta : http://localhost:5283/api/cliente/ConPagosYReprensentante

![Captura de pantalla 2023-11-23 162848](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/db2a3c02-304b-4275-adb7-3e8adb3b17c7)

<br>

Explicacion : Con where le digo que me envie los cliente que tenga almenos un pedido y con select tomo los datos que nesesito en un objeto 

<br><br>

### Devuelve un listado que muestre el nombre de cada empleado, el nombre de su gefe y el nombre del gefe de su gefe

Ruta : http://localhost:5283/api/empleado/EmpleadosYGefes

![Captura de pantalla 2023-11-23 163935](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/69ba538c-47dc-4d57-a94f-f80b5bc6d969)

<br>

Explicacion : tomo los datos que nesesito y con funciones ternarias le envio "No tiene gefe" si no lo tiene o el nombre del gefe si lo tiene 

<br><br>

###  Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripcion y la imagen del producto

Ruta : http://localhost:5283/api/producto/SinPedidos

![Captura de pantalla 2023-11-23 165028](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/f665c95a-403c-4571-b1c7-9263984723fc)

<br>

Explicacion : Con where le digo que me envie los productos que tengan 0 detallesPedidos y con select tomo los datos que nesesito en un objeto  

<br><br>

###  Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripcion y la imagen del producto (Segunda Vez)

Ruta : http://localhost:5283/api/producto/SinPedidos

![Captura de pantalla 2023-11-23 165028](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/f665c95a-403c-4571-b1c7-9263984723fc)

<br>

Explicacion : Con where le digo que me envie los productos que tengan 0 detallesPedidos y con select tomo los datos que nesesito en un objeto  



<br><br>

### Cuantos pedidos hay en cada estado ordena el resultado de forma descendente por el numero de pedidos

Ruta : http://localhost:5283/api/pedido/PedidosXEstados

![Captura de pantalla 2023-11-23 170610](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/4483f37f-e9ba-4f18-b1f9-cc339053469f)

<br>

Explicacion : Con select tomo todos los nombres de estado de los pedidos y con Distinct le digo que no se repitan y hago una nueva consula para pedir la cantidad de pedidos que tiene ese estado

<br><br>


###  Devuelve un listado que muestre solamente los clientes que nos han realizado ningun pago


Ruta : http://localhost:5283/api/cliente/SinPagos


![Captura de pantalla 2023-11-23 171207](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/d8751669-09ba-41ec-9ed4-b51443d221d2)

<br>

Explicacion : con where le digo que tome todos los clientes que tengan 0 pagos y que me devuleva toda la info del cliente

<br><br>


### Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad de su oficna


Ruta : http://localhost:5283/api/cliente/YReprensentante


![Captura de pantalla 2023-11-23 171837](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/14b0a596-c502-41fd-8973-90893825b71e)

<br>

Explicacion : Como no hay restricion solo pido todos los clientes y con select tomo los datos que nesesito en un objeto 

<br><br>

### Devuelve el listado de clientes, el nombre y primer apellido de su representante de ventas y el numero
de telefono de la oficina del representante de ventas de aquellos cloentes que no hayan realizado ningun pago


Ruta : http://localhost:5283/api/cliente/SinPagosYSusReprensentante

![Captura de pantalla 2023-11-23 172541](https://github.com/julianlpz69/FiltroFinalJulian/assets/131847060/f058bec5-e867-42ec-b776-03dc8b9126d5)

<br>

Explicacion : con where tomo los clientes que tenga 0 pagos y con select tomo los datos que nesesito en un objeto 
