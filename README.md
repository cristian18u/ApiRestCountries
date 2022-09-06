# ApiRestCountries

Api-rest de countries usando el entorno de programacion .net core (c#) y mongodb

# Podemos mirar toda la documentacion y probar las rutas en swagger
https://app.swaggerhub.com/apis-docs/cristian18u/Apirest-Countries/v1

# metodos get

usamos el metodo get para acceder a todos los paises con este endpoint

https://apirest-netcore.herokuapp.com/api/countries
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/hfxrmmiefuvyi8hlfcvl.png)

luego para filtrar por Id, escribimos el id luego de countries/ ej:
https://apirest-netcore.herokuapp.com/api/countries/6307e4ec337d3991748704e1
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/dao7pszoi5pswjmla29w.png)

luego usando el metodo query params podemos filtrar por nombre con la siguiente ruta ej:

https://apirest-netcore.herokuapp.com/api/countries/filter?name=Argentina
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/bdaqzb4y81pybcd5bixj.png)

# metodo post

con el metodo post podemos agregar un nuevo pais a la base de datos

mandandole la informacion por body usando el mismo endpoint
https://apirest-netcore.herokuapp.com/api/countries

![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/kwt9lkeco1vajkma9etp.png)
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/vlxopw5vhoe7sp4beekg.png)

con el mismo endpoint tambien podemos acceder a los metodos

# put

para actualizar un dato en la base de datos

![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463219/cris/nnlmvmi8x7d9dgerhgkj.png)
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463220/cris/rob8lxen88ujlx0cpgqv.png)

y

# delete

para borrar un elemento en la base de datos
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463220/cris/mqv2hgjzi8qboqjcxqxh.png)
![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661463220/cris/panjhh50aahexnb7zjaz.png)

# pasos para la creacion de la api rest

inicialmente consumimos la informacion de este endpoint:

https://restcountries.com/v3/all

luego hice la conexion entre net core y mongodb

luego saque solo la informacion que necesitaba para cargar la base de datos

# funcion para cargar la base de datos

![Image text](https://res.cloudinary.com/cristian18u/image/upload/v1661464031/cris/sfu5eh2t5qfc0qfficeo.png)

y luego solo fue crear la rutas
