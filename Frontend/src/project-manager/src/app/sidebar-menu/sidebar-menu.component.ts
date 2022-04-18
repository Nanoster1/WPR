import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {isSmallScreen} from "../../services/ScreenService";

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.sass',"../app.component.sass"]
})
export class SidebarMenuComponent implements OnInit {

  isOpen: boolean = false;
  @Output() menuObserver = new EventEmitter<boolean>();

  //@Output() menuSize = new EventEmitter<>
  ngOnInit(): void {
    this.menuObserver.subscribe(value => this.isOpen = value);
  }

  isSmallDisplay(): boolean {
    return isSmallScreen();
  }
}
