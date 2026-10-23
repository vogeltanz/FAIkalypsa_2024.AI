FAIkalypsa - GitHub Copilot Instructions

Project purpose

FAIkalypsa is an educational 3D game project developed with Unity.

The project is primarily intended for teaching university students game development and software engineering principles. Code should therefore not only be functional, but also readable, maintainable, well-structured, and suitable as an educational example.

Prefer clear and understandable solutions over unnecessarily clever or over-engineered implementations.

General development rules

Follow the existing conventions and architecture of the project.
Follow SOLID principles.
Prefer composition over inheritance where appropriate.
Keep classes focused on a single responsibility.
Use meaningful and descriptive names for classes, methods, fields, and variables.
Avoid unnecessary code duplication.
Reuse existing abstractions and components when they provide the required functionality.
Do not introduce new architectural patterns, frameworks, or dependencies unless they provide a clear benefit for the requested change.
Do not perform unrelated refactoring.
Keep changes focused on the assigned issue.

Unity-specific rules

Follow established Unity development practices.
Keep gameplay and domain logic independent of MonoBehaviour and other Unity-specific APIs where practical.
Use MonoBehaviour primarily as an integration point between Unity and game logic rather than as a container for all application logic.
Prefer composition of GameObjects and components over deep inheritance hierarchies.
Use serialized fields where configuration through the Unity Inspector is appropriate.
Preserve Unity .meta files.
Do not manually modify Unity-generated project files.
Do not modify scenes, prefabs, animations, materials, terrain, or other serialized assets unless the assigned issue explicitly requires it.
Do not replace or modify third-party assets unless the assigned issue explicitly requires it.
Do not use old Input System in Unity.

Architecture and design

Before implementing a change:

Inspect the existing implementation related to the requested functionality.
Identify existing interfaces, components, services, or abstractions that should be reused.
Preserve existing architectural boundaries and dependency directions.
Prefer extending the existing design over creating a parallel implementation of the same concept.

When introducing new functionality:

Separate responsibilities where this improves clarity and testability.
Depend on abstractions where multiple implementations or substitution are meaningful.
Do not introduce interfaces mechanically when there is no architectural reason for them.
Avoid global mutable state.
Avoid introducing new Singleton or Service Locator patterns.
Prefer dependency injection or explicit dependency composition where appropriate.
Avoid tightly coupling otherwise independent gameplay systems.

Code quality

Code in this repository is also teaching material.

Therefore:

Write code that students can reasonably understand and learn from.
Prefer explicit and readable code over unnecessarily compact code.
Keep methods reasonably focused and short where practical.
Avoid unnecessary complexity and premature abstraction.
Avoid magic values when a named constant or configurable value is more appropriate.
Consider null references and invalid state where relevant.
Do not suppress errors merely to make the implementation appear functional.
Do not leave commented-out obsolete code.

Changes and scope

Implement only changes necessary to satisfy the assigned issue and its acceptance criteria.

Do not:

refactor unrelated systems;
rename unrelated classes or files;
reorganize directories without a clear requirement;
change public APIs unnecessarily;
upgrade Unity or project dependencies unless explicitly requested;
introduce unrelated features.
If an issue appears to require a substantial architectural change beyond its stated scope, keep the implementation conservative and explain the concern in the pull request instead of performing a large unsolicited redesign.

Testing and validation

Preserve existing functionality unless the issue explicitly requires a behavioral change.
Run available relevant tests after making changes.
Add tests for new logic when the logic can reasonably be tested automatically.
Prefer keeping testable game logic separated from Unity-specific behavior where practical.
Do not modify tests merely to make an incorrect implementation pass.
When automated validation is not possible, clearly state what still requires manual validation in Unity.

Pull requests

When completing an assigned task:

Keep the pull request focused on the issue.
Clearly summarize what was changed.
Explain important architectural or design decisions.
State what validation or tests were performed.
Identify anything that still requires manual verification in the Unity Editor.
Mention limitations or uncertainties instead of hiding them.
