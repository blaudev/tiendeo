# Prueba t�cnica de Tiendeo #

## Descripci�n ##
El reto consiste en desplazar unos drones a trav�s de un �rea. No se especifica tama�o del �rea ni tiempo necesario ni n�mero l�mite de drones a utilizar.

Seg�n la descripci�n del ejercicio no me queda claro si los datos de posici�n, direcci�n y acciones que deben realizar los drones ser�n facilitados o por el contrario hay que crear alg�n tipo de algoritmo que los cree. Por asegurar he creado un par de Data Providers que se encargar�n de facilitar estos datos.

Al finalizar el recorrido se deben mostrar tanto los datos de entrada como la posici�n y direcci�n de todos los drones en el momento de finalizar el rastreo.

## Data Providers ##
Todos los **Data Providers** deber�n implementar la interface <code>IDataProvider</code>. Cada data provider tendr� su propio algoritmo. Los datos se devolver�n a trav�s del m�todo <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba t�cnica. Se utilizan los datos que se facilitan como muestra en la propia prueba t�cnica.

### HorizontalDataProvider ###
Crea tantos drones como altura tiene el �rea. Los drones se posicionan en el punto inical del eje X y el eje Y aumenta seg�n la altura del �rea. Cada dron apunta a 'E' (Este) y tiene tantas acciones 'M' (Mover) como anchura tiene el �rea. De esto modo los drones barrer�n el total del �rea de Oeste a Este de forma paralela y al mismo tiempo.

## Drones Manager ##
Desacoplamos la aplicaci�n del manejador de drones por si queremos cambiar este o simplemente aumentar su versi�n. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el �nico manejador de drones del que disponemos.

Con el m�todo <code>CreateDrones</code> creamos los drones a trav�s de los datos conseguidos a trav�s del Data Provider. Estos drones tendr�n su posici�n y direcci�n iniciales, as� como sus respectivas acciones.

<code>ExecuteActionsAsync</code> ejecuta todas las acciones de un dron. Se ejecuta de forma as�ncrona para simular que hay un retardo en el movimiento del dron.

## App ##
App es el core de la aplicaci�n. Se encarga de ejecutar de forma as�ncrona las acciones de todos los drones. Tambi�n reportar� los datos finales de posici�n y direcci�n de todos los drones.

## A tener en cuenta ##
- <code>is</code> e <code>is not</code> en lugar de <code>==</code> y <code>!=</code>
- <code>records</code> para promover la inmutabilidad.
- Inyecci�n de dependencias para no acloplar la l�gica al Data Provider ni al Manager.
- Nuevos <code>switch</code>
- M�todos as�ncronos para que los drones se puedan moven al mismo tiempo.
- Nueva manera de instanciar clases con <code>new()</code>
- Separaci�n de capas

## Aclaraciones ##
- Ten�a intenci�n de hacer todo m�s sencillo, sin utilizar clases ni records, modificando los datos directamente con <code>string</code> y <code>char</code>. El c�digo final hubiera sido mucho m�s sencillo. Quiz�s correcto para una prueba t�cnica pero nada escalable.
- No he hecho testing por no alargar m�s la prueba y porque no se ped�a. Aun as� todos los m�todos est�n preparados y pensados para testing uitario de forma sencilla.
- No he documentado aquelos m�todos ni funciones en las que por sem�ntica ya se entend�a su funci�n.

## Tiempo empleado ##
- Planificaci�n: le he estado dando muchas vueltas durante todo el fin de semana. Es dif�cil de cuantificar. M�nimo una hora, m�ximo 2.
- Primera parte: aplicaci�n, generador de datos de test, modelos y manager de drones: 2h 45m
- Segunda parte: generador de datos: 15 minutos
- Final: documentaci�n, refactoring y test: 45 minutos
