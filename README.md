# Prueba técnica de Tiendeo #

## Data Providers ##
Todos los **Data Providers** deberán implementar la interface <code>IDataProvider</code>. Cada data provider tendrá su propio algoritmo. Los datos se devolverán a través del método <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba técnica. Sólo válido para test.

## Drones Manager ##
Desacoplamos la aplicación del manejador de drones por si queremos cambiar este o simplemente aumentar su versión. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el único manejador de drones del que disponemos.

Con el método <code>CreateDrones</code> creamos los drones a través de los datos pasados. Estos drones tendrán su posición y dirección iniciales, así como sus respectivas acciones.

<code>ExecuteActionsAsync</code> ejecuta todas las acciones de un dron. Se ejecuta de forma asíncrona para simular que hay un retardo en el movimiento del dron.

## App ##
App es el core de la aplicación. Se encarga de ejecutar de forma asíncrona las acciones de los drones, así como reportar los datos finales.

## Tiempo empleado ##
Planificación: le he estado dando muchas vueltas durante todo el fin de semana. Es difícil de cuantificar. Mínimo una hora, máximo 2.
Primera parte: aplicación, generador de datos de test, modelos y manager de drones: 2h 45m
Segunda parte: generador de datos:
Final: documentación, refactoring y test: 
