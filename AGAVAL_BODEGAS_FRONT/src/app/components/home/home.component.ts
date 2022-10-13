import { Component, OnInit } from '@angular/core';
import { AzureAdService } from 'src/app/services/azure-ad-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isUserLoggedIn: boolean = false;
  constructor(private azureAdService: AzureAdService) { }

  ngOnInit(): void {
    this.azureAdService.isUserLoggedIn.subscribe(
      x => { this.isUserLoggedIn = !x }
    )
  }

}
