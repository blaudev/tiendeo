# Prueba técnica de Tiendeo #

## IDataProvider ##
Podremos tener varios proveedores de datos, dependiendo de qué algoritmo de barrido utilicemos. Los Proveedores de datos implementarán la interface <code>IDataProvider</code>. A través de su único método <code>CreateData</code> devolveremos un <code>string</code> con los datos de área y posción inical y acciones de cada dron.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba técnica. Sólo válido para test.
