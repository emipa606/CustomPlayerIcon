# GitHub Copilot Instructions for Custom Player Icon (Continued) Mod

## Overview and Purpose
The "Custom Player Icon (Continued)" mod is an enhanced version of the original mod created by Ogam. The purpose of this mod is to allow players to customize their player icons in RimWorld. It utilizes icons from the Ideology DLC along with additional icons provided by other mods. Furthermore, it supports custom user icons, which can be easily added through the file directory.

## Key Features and Systems
- **Custom Icons:** Players can add their own custom icons by placing 64x65 (or larger) images in the specified directory (`steamapps\workshop\content\294100\3290779422\Textures\CustomPlayerIcons`). This feature allows for personalization and flexibility in icon choice.
- **Integration with DLC and Other Mods:** The mod supports icons from the Ideology DLC and any other installed mods, broadening the choice of icons available to players.
- **In-Game Icon Selection:** Includes a user-friendly dialog within the game to select and change player icons.

## Coding Patterns and Conventions
- **C# Conformance:** Code is written in C# with types and members following PascalCase naming conventions. The main classes involved include `Core`, `CustomPlayerIconComponent`, and various dialog and patching classes.
- **XML Conventions:** The XML file `About.xml` provides necessary metadata for the mod.
- **File Structure:** Class files are named after the main class they contain, aligning with common C# practices for easier maintainability.

## XML Integration
- The mod contains an `About.xml` file used for mod metadata. This XML file is essential to define mod properties such as name, author, and version, and should conform to typical RimWorld XML modding standards.

## Harmony Patching
- The mod utilizes Harmony (`brrainz.harmony` dependency) to apply patches, allowing for modification of existing game behavior without altering the original codebase.
- **Prefix and Postfix Methods:** These are used to modify game behavior. For instance, `Faction_Color` uses a Prefix to alter faction color settings, while `Settlement_GetGizmos` uses a Postfix to adjust settlement controls.

## Suggestions for Copilot
- **Adding New Icons:** Provide code snippets to automate the process of importing and assigning new custom player icons from the specified directory.
- **Dialog Enhancements:** Suggest enhancements for the in-game icon selection dialog, making it more intuitive or visually appealing.
- **Performance Optimization:** Offer suggestions to optimize any existing Harmony patches to ensure smooth gameplay.
- **Error Handling:** Suggest implementations for improved error logging and user notifications for any issues with icon compatibility.
- **Documentation Generation:** Aid in the creation of additional XML documentation comments within C# files for better code understanding and maintenance.

By using these instructions for guidance, you can ensure consistent development practices and maintainability for the "Custom Player Icon (Continued)" mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

