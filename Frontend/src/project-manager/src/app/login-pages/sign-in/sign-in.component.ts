import {Component, OnInit} from "@angular/core";
import {delay} from "../../../services/timeServices";

@Component({
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.sass', '../login.sass']
})
export class SignInComponent implements OnInit {
  text: string = ""

  ngOnInit(): void {
    const title = document.getElementById('#title');
    const secretText = "Welcome to WPR!\nHere we go are again"

    secretText.split('').forEach(
      (x, index) => {
        delay(100 * index, () => {
          if (title != null)
            this.text += x;
        })
      }
    )
  }


}
