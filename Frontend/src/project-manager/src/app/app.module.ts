import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {MainTemplateComponent} from "./main-template/main-template.component";
import {MainTemplateModule} from "./main-template/main-template.module";
import {SidebarMenuComponent} from './sidebar-menu/sidebar-menu.component';
import {HttpClientModule} from "@angular/common/http";
import {LoginPageComponent} from "./login-page/login-page.component";

@NgModule({
  declarations: [
    AppComponent,
    MainTemplateComponent,
    SidebarMenuComponent,
    LoginPageComponent,
  ],
  imports: [
    BrowserModule,
    MainTemplateModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
