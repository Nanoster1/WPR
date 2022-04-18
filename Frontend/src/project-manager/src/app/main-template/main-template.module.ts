import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {MainTemplateComponent} from "./main-template.component";
import {FooterComponent} from "./footer/footer.component";
import {HeaderComponent} from "./header/header.component";

@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
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
