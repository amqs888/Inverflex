# ADR-001: Autorización RBAC con política de asignación persistida

- **Estado:** Aceptado
- **Contexto:** los roles cliente, asesor y admin describen capacidades generales; los asesores además solo pueden operar sobre clientes asignados.
- **Decisión:** RBAC para capacidades (`[Authorize(Roles=...)]`) y `PortfolioAccessService` como única política de alcance de cliente. La asignación asesor-cliente se consulta en `AdvisorAssignments` en SQLite; admin omite el filtro. Los servicios vuelven a verificar asignaciones al aprobar órdenes.
- **Consecuencias:** los controladores no replican joins de autorización. JWT contiene solo `userId`, `role`, `sub`, `jti` y metadatos de expiración; jamás saldo. Para reglas futuras por atributo, extender el servicio de autorización en lugar de insertar condiciones en cada endpoint.
