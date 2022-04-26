import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {MainTemplateComponent} from "./main-template.component";
import {FooterComponent} from "./footer/footer.component";
import {HeaderComponent} from "./header/header.component";
import {RouterModule} from "@angular/router";

@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
  ],
  providers: [],
  exports: [
    FooterComponent,
    HeaderComponent
  ],
  bootstrap: [MainTemplateComponent]
})
export class MainTemplateModule {

}
