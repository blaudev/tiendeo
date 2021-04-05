# Prueba técnica de Tiendeo #

## Descripción ##
El reto consiste en desplazar unos drones a través de un área. No se especifica tamaño del área ni tiempo necesario ni número límite de drones a utilizar.

Según la descripción del ejercicio no me queda claro si los datos de posición, dirección y acciones que deben realizar los drones serán facilitados o por el contrario hay que crear algún tipo de algoritmo que los cree. Por asegurar he creado un par de Data Providers que se encargarán de facilitar estos datos.

Al finalizar el recorrido se deben mostrar tanto los datos de entrada como la posición y dirección de todos los drones en el momento de finalizar el rastreo.

## Data Providers ##
Todos los **Data Providers** deberán implementar la interface <code>IDataProvider</code>. Cada data provider tendrá su propio algoritmo. Los datos se devolverán a través del método <code>CreateData</code>.

### TestDataProvider ###
Es un proveedor de datos para test. Devuelve los datos de muestra que se ofrecen en la prueba técnica. Se utilizan los datos que se facilitan como muestra en la propia prueba técnica.

### HorizontalDataProvider ###
Crea tantos drones como altura tiene el área. Los drones se posicionan en el punto inical del eje X y el eje Y aumenta según la altura del área. Cada dron apunta a 'E' (Este) y tiene tantas acciones 'M' (Mover) como anchura tiene el área. De esto modo los drones barrerán el total del área de Oeste a Este de forma paralela y al mismo tiempo.

## Drones Manager ##
Desacoplamos la aplicación del manejador de drones por si queremos cambiar este o simplemente aumentar su versión. Para ello deberemos implementar la interface <code>IDronesManager</code>.

## SimpleDronesManager ##
Se encarga de posicionar y mover los drones. Por el momento es el único manejador de drones del que disponemos.

Con el método <code>CreateDrones</code> creamos los drones a través de los datos conseguidos a través del Data Provider. Estos drones tendrán su posición y dirección iniciales, así como sus respectivas acciones.

<code>ExecuteActionsAsync</code> ejecuta todas las acciones de un dron. Se ejecuta de forma asíncrona para simular que hay un retardo en el movimiento del dron.

## App ##
App es el core de la aplicación. Se encarga de ejecutar de forma asíncrona las acciones de todos los drones. También reportará los datos finales de posición y dirección de todos los drones.

## A tener en cuenta ##
- <code>is</code> e <code>is not</code> en lugar de <code>==</code> y <code>!=</code>
- <code>records</code> para promover la inmutabilidad.
- Inyección de dependencias para no acloplar la lógica al Data Provider ni al Manager.
- Nuevos <code>switch</code>
- Métodos asíncronos para que los drones se puedan moven al mismo tiempo.
- Nueva manera de instanciar clases con <code>new()</code>
- Separación de capas

## Aclaraciones ##
- Tenía intención de hacer todo más sencillo, sin utilizar clases ni records, modificando los datos directamente con <code>string</code> y <code>char</code>. El código final hubiera sido mucho más sencillo. Quizás correcto para una prueba técnica pero nada escalable.
- No he hecho testing por no alargar más la prueba y porque no se pedía. Aun así todos los métodos están preparados y pensados para testing uitario de forma sencilla.
- No he documentado aquelos métodos ni funciones en las que por semántica ya se entendía su función.

## Tiempo empleado ##
- Planificación: le he estado dando muchas vueltas durante todo el fin de semana. Es difícil de cuantificar. Mínimo una hora, máximo 2.
- Primera parte: aplicación, generador de datos de test, modelos y manager de drones: 2h 45m
- Segunda parte: generador de datos: 15 minutos
- Final: documentación, refactoring y test: 45 minutos
