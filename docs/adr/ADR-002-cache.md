# ADR-002: Redis distribuido con invalidación tras ejecución

- **Estado:** Aceptado
- **Contexto:** consultas frecuentes de portafolio y catálogo, en varias instancias sin estado local.
- **Decisión:** Redis `IDistributedCache`; catálogo de precios TTL 60 s y portafolio calculado TTL 5 min. Al confirmar una orden que modifica posiciones, se elimina `portfolio:v1:{clientId}`. El TTL limita la obsolescencia si la invalidación no llega a Redis; no se usa `IMemoryCache`.
- **Consecuencias:** coherencia eventual acotada por TTL, con invalidación inmediata en el camino normal. La escritura de DB y Redis no es una transacción distribuida; monitorear errores de invalidación y usar outbox si el requisito operativo exige garantía de entrega. Las claves están versionadas para invalidación masiva por cambio de esquema.
