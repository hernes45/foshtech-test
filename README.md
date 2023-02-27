# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.


## Requisitos 

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.

## Comentarios de la prueba
He divido el proyecto en 3 capas principales con el objetivo de evolucionar este proyecto con arquitecturas CLEAN.
- Aplicación
API, WEB, etc.
- Presentación
Managers, Servicios, Modelos vistas, etc.
- Dominio
Modelos DTO, Repositorios, helpers, etc.

Cada proyecto tiene su propio proyecto de UT en el que cada clase tiene correspondiente clase de UT.  Para la prueba, disculpad, pero no he terminado todos los UTs de todas las clases, pero con los que he hecho creo que se ve claro la filosofía que sigo para completarlo, espero que sea suficiente.

Se ha preparado la arquitectura para poder separar ciertas partes, que a mi parecer, pueden separarse en Microservicios distintos, aunque por el momento están en ficheros locales.
