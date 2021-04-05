# Prueba t�cnica de Tiendeo #

## Data Providers ##
Todos los **Data Providers** deber�n implementar la interface <code>IDataProvider</code>. Cada data provider tendr� su propio algoritmo. Los datos se devolver�n a trav�s del m�todo <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba t�cnica. S�lo v�lido para test.

## Drones Manager ##
Desacoplamos la aplicaci�n del manejador de drones por si queremos cambiar este o simplemente aumentar su versi�n. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el �nico manejador de drones del que disponemos.
