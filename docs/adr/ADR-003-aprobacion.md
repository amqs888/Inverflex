# ADR-003: Máquina de estados con transición condicional

- **Estado:** Aceptado
- **Contexto:** órdenes superiores a USD 50.000 necesitan aprobación y dos asesores pueden actuar simultáneamente.
- **Decisión:** estados `PendienteAprobacion`, `Ejecutada`, `Cancelada`; la política pura `OrderApprovalPolicy` verifica monto, estado y rol. La aprobación ejecuta un `UPDATE ... WHERE Status = PendienteAprobacion` dentro de una transacción y solo el proceso que modifica exactamente una fila aplica la posición. Se guarda aprobador y fecha.
- **Consecuencias:** la condición SQL serializa la transición y una segunda aprobación recibe conflicto (409); el índice/versión facilita concurrencia optimista. La operación de posición y la transición se confirman juntas en SQLite.
