# Prueba t�cnica de Tiendeo #

## Data Providers ##
Todos los **Data Providers** deber�n implementar la interface <code>IDataProvider</code>. Cada data provider tendr� su propio algoritmo. Los datos se devolver�n a trav�s del m�todo <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba t�cnica. S�lo v�lido para test.

## Drones Manager ##
Desacoplamos la aplicaci�n del manejador de drones por si queremos cambiar este o simplemente aumentar su versi�n. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el �nico manejador de drones del que disponemos.

Con el m�todo <code>CreateDrones</code> creamos los drones a trav�s de los datos pasados. Estos drones tendr�n su posici�n y direcci�n iniciales, as� como sus respectivas acciones.

<code>ExecuteActionsAsync</code> ejecuta todas las acciones de un dron. Se ejecuta de forma as�ncrona para simular que hay un retardo en el movimiento del dron.

## App ##
App es el core de la aplicaci�n. Se encarga de ejecutar de forma as�ncrona las acciones de los drones, as� como reportar los datos finales.

## Tiempo empleado ##
Planificaci�n: le he estado dando muchas vueltas durante todo el fin de semana. Es dif�cil de cuantificar. M�nimo una hora, m�ximo 2.
Primera parte: aplicaci�n, generador de datos de test, modelos y manager de drones: 2h 45m
Segunda parte: generador de datos:
Final: documentaci�n, refactoring y test: 
