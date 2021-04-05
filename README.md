# Prueba t�cnica de Tiendeo #

## IDataProvider ##
Podremos tener varios proveedores de datos, dependiendo de qu� algoritmo de barrido utilicemos. Los Proveedores de datos implementar�n la interface <code>IDataProvider</code>. A trav�s de su �nico m�todo <code>CreateData</code> devolveremos un <code>string</code> con los datos de �rea y posci�n inical y acciones de cada dron.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba t�cnica. S�lo v�lido para test.
