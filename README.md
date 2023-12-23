# SignalR
clients: WPF, Angular;
server: .Net Core 6 WebAPI
server-client

Create new web app(Angular):
---------------------------
C:\Users\user\Desktop\Chat>ng new Chat.WebUI --no-standalone
? Which stylesheet format would you like to use? CSS
? Do you want to enable Server-Side Rendering (SSR) and Static Site Generation (SSG/Prerendering)? Yes

Open app in VSCode:
-------------------
C:\Users\user\Desktop\Chat>cd Chat.WebUI
C:\Users\user\Desktop\Chat\Chat.WebUI>code .

Generate service SignalR:
-------------------------
cd src/app
mkdir services
cd src/app/services
ng generate service signalr --skip-tests
? Would you like to share pseudonymous usage data about this project with the Angular Team
at Google under Google's Privacy Policy at https://policies.google.com/privacy. For more
details and how to change this setting, see https://angular.io/analytics. Yes

Install @microsoft/signalr:
---------------------------
C:\Users\user\Desktop\Chat\Chat.WebUI\src\app\services>npm install @microsoft/signalr

Generate interface IPrivateMessage:
-----------------------------------
cd src/app
mkdir interfaces
cd interfaces
ng generate interface IPrivateMessage

Add bootstrap:
--------------
C:\Users\user\Desktop\Chat\Chat.WebUI>ng add @ng-bootstrap/ng-bootstrap

Generate component login-form-dialog:
-------------------------------------
C:\Users\user\Downloads\GitHubProjects\SignalR\Chat.WebUI\src\app>ng generate component login-form-dialog

Add material (MatDialog, open dialog form):
-------------------------------------------
C:\Users\user\Desktop\Chat\Chat.WebUI>ng add @angular/material

For using [(ngModel)] in html:
------------------------------
***************
*app.module.ts*
***************
import { FormsModule } from '@angular/forms';
imports: [..., FormsModule, ...]

Simple run project:
-------------------
C:\Users\user\Downloads\GitHubProjects\SignalR\Chat.WebUI>ng serve --o