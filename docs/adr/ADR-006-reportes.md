# ADR-006: Reporte sincrónico JSON/CSV

- **Estado:** Aceptado
- **Contexto:** el alcance inicial pide reporte estructurado, sin obligación de archivo físico ni volumen masivo.
- **Decisión:** consulta sincrónica para los clientes asignados; JSON por defecto y CSV descargable como alternativa. Devuelve valor/rendimiento de portafolio al momento de cálculo y flujos/órdenes ejecutadas del periodo solicitado.
- **Consecuencias:** respuesta sencilla para la demo y sin estado de jobs. La valuación corresponde a la fecha `asOf` (no reconstruye precios históricos); para reportes históricos auditables se almacenarán snapshots diarios. Para periodos extensos o exportaciones pesadas se migrará a job asíncrono con estado persistido, polling y almacenamiento de objetos.
