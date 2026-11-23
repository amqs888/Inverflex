# ADR-007: Fallo explícito del precio de mercado

- **Estado:** Aceptado
- **Contexto:** las órdenes y la valoración dependen del precio, y un precio antiguo podría ejecutar una operación a precio incorrecto.
- **Decisión:** el mock implementa `IMarketPriceService`; errores de proveedor se propagan para no ejecutar órdenes ni presentar una cotización como actual. El catálogo conserva precios cacheados por 60 s, pero al expirar y no estar disponible el proveedor, retorna error en vez de un fallback silencioso.
- **Consecuencias:** disponibilidad menor ante fallo del proveedor, pero no se confunde último precio con precio actual. En producción, adaptar circuit breaker/timeouts y devolver `503` explícito; cualquier dato stale deberá marcarse con `asOf` y advertencia visible.
