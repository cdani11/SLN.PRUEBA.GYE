# Prueba Netby por Carlos Tigrero

Se crea la solución SLN.PRUEBA.GYE, en el cual se crean 3 proyectos tipo **ASP.NET Core Web API (donet8.0)**, los mismo se ubican en la ruta *"1. PRESENTATION/1.2 APIS"*:

* PRUEBA.AUTH.API (autenticación)
* PRUEBA.ADMIN.API (api producto)
* PRUEBA.TRANSAC.API (api transacciones)

## Ejecución

Puedes ejecutar la solucion desde VSCode o Visual Studio 2022 o superior.

En VSCode se encuentra el archivo ".vscode/launch.json" ya configurado, puedes ir a la opción **RUN AND DEBUG** y seleccionar **Start APIs Debug** de la lista desplegable. Las apis se levantan en los puertos definidos por el archivo "Properties/launchSettings.json" de cada proyecto web.

## Script de base

Se encuentra ubicado en la carpeta DBScript/database.sql

## Conexión base y APIs

En cada proyecto web encontraras la carpeta "Settings" en ella se encuentra el archivo de configuración por cada ambiente, leemos y establecemos el ambiente mediante la variable de entorno **ASPNETCORE_ENVIROMENT** la cual esta en *Development* asi que debes editar el archivo terminado en dev "appsettings-dev.json", solo cambia la instancia, usuario y clave de tu servidor de base de datos.

**Nota:** Recuera no cambiar ningun valor de //url:port en los archivos de configuración, las conexiones entre APIs y Sitio Web deberian tomar su configuración establecida.

## ¡IMPORTANTE!

El sitio web, al ser un proyecto angular se ubico en otro repo, debes ir a descarlo para que todo funcione, es decir, APIs y Sitio Web.

El enlace al otro repo es: https://github.com/cdani11/PRUEBA-TECNICA-VIEW
