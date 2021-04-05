# Prueba técnica de Tiendeo #

## Data Providers ##
Todos los **Data Providers** deberán implementar la interface <code>IDataProvider</code>. Cada data provider tendrá su propio algoritmo. Los datos se devolverán a través del método <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba técnica. Sólo válido para test.

## Drones Manager ##
Desacoplamos la aplicación del manejador de drones por si queremos cambiar este o simplemente aumentar su versión. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el único manejador de drones del que disponemos.
