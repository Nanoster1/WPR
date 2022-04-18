import {
  AfterViewInit,
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
  ViewChild
} from "@angular/core";
import {fromEvent, Observable, Subscription} from "rxjs";
import {isSmallScreen} from "../../../services/ScreenService";

@Component({
  selector: 'app-header',
  styleUrls: ['./header.component.sass', '../main-template.component.sass'],
  templateUrl: './header.component.html',
})

export class HeaderComponent implements OnDestroy, OnInit, AfterViewInit {

  imgLink = "#";
  mainImg = "../../../assets/images/logo.png"
  signIn = "#";
  signUp = "#"
  private minWidth = 768;
  private resizeObservable: Observable<Event> = fromEvent(window, 'resize')
  private resizeSubscription: Subscription = new Subscription()

  @ViewChild('header') header: ElementRef | undefined
  @ViewChild('signIn') signInObj: ElementRef | undefined;
  @Output() height = new EventEmitter<number>();
  @Output() width = new EventEmitter<number>();
  @Input() needBorder = false;

  private static changeSignMenu(signInObj: ElementRef | undefined, minWidth: number) {
    if (signInObj != undefined) {
      const signBlock = signInObj.nativeElement;
      if (isSmallScreen())
        signBlock.classList.add("hide");
      else if (signBlock.classList.contains("hide"))
        signBlock.classList.remove("hide");
    }
  }

  ngOnInit() {
    this.resizeSubscription = this.resizeObservable.subscribe(() => {
      HeaderComponent.changeSignMenu(this.signInObj, this.minWidth);
    })
  }

  ngOnDestroy() {
    this.resizeSubscription.unsubscribe()
    this.height.unsubscribe();
    this.width.unsubscribe();
  }

  ngAfterViewInit(): void {
    HeaderComponent.changeSignMenu(this.signInObj, this.minWidth)
    Promise.resolve().then(() => this.height.emit(this.header?.nativeElement.offsetHeight));
    Promise.resolve().then(() => this.height.emit(this.header?.nativeElement.offsetHeight));
  }
}



