import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {MainTemplateComponent} from "./main-template/main-template.component";
import {MainTemplateModule} from "./main-template/main-template.module";
import {SidebarMenuComponent} from './sidebar-menu/sidebar-menu.component';
import {HttpClientModule} from "@angular/common/http";
import {SignInComponent} from "./login-pages/sign-in/sign-in.component";
import {Routes,RouterModule} from "@angular/router";
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const appRoutes: Routes =[
  {path:'', component:MainTemplateComponent},
  {path:'sign-in', component:SignInComponent},
  {path:'**',component: AppComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    MainTemplateComponent,
    SidebarMenuComponent,
    SignInComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    MainTemplateModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
