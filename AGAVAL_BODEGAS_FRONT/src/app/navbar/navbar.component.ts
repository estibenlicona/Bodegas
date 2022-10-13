import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { MsalBroadcastService, MsalGuardConfiguration, MsalService, MSAL_GUARD_CONFIG } from '@azure/msal-angular';
import { InteractionStatus, RedirectRequest } from '@azure/msal-browser';
import { filter, Subject, takeUntil } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AzureAdService } from '../services/azure-ad-service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isUserLoggedIn: boolean = false;
  private readonly _destroy = new Subject<void>();
  showFiller: boolean = false;
  panelOpenState: boolean = false;
  @Input() inputDrawer!: MatDrawer;
  constructor(
    @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private msalBroadCastService: MsalBroadcastService,
    private authService: MsalService,
    private azureAdService: AzureAdService
    ) { }

  ngOnInit(): void {
    this.msalBroadCastService.inProgress$.pipe(
      filter((interactionStatus:InteractionStatus) =>
        interactionStatus == InteractionStatus.None),
        takeUntil(this._destroy))
      .subscribe(x => {
        this.isUserLoggedIn = this.authService.instance.getAllAccounts().length > 0;
        this.azureAdService.isUserLoggedIn.next(this.isUserLoggedIn);
      })
  }

  OnDestroy() : void{
    this._destroy.next(undefined);
    this._destroy.complete();
  }

  login(){
    if(this.msalGuardConfig.authRequest){
      this.authService.loginRedirect({ ...this.msalGuardConfig.authRequest } as RedirectRequest)
    }else{
      this.authService.logoutRedirect();
    }
  }

  logout(){
    this.authService.logoutRedirect({ postLogoutRedirectUri: environment.urlRedirect })
  }

}
