//Modules
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RoutesModule } from "../app/router/routes/routes.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

//Material Modules
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatRippleModule } from '@angular/material/core';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';

//Components
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ListarBodegasComponent } from './components/bodega/list/list.component';
import { CrearBodegaComponent  } from './components/bodega/crear/crear.component';
import { FilterComponent } from './components/shared/filter/filter.component';
import { InteractionType, PublicClientApplication } from '@azure/msal-browser';
import { MsalGuard, MsalInterceptor, MsalModule, MsalRedirectComponent } from '@azure/msal-angular';

//Service
import { AzureAdService } from './services/azure-ad-service';
import { HomeComponent } from './components/home/home.component';
import { environment } from 'src/environments/environment';

const isIE=window.navigator.userAgent.indexOf('MSIE')>-1 || window.navigator.userAgent.indexOf('Trident/')>-1;

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListarBodegasComponent,
    CrearBodegaComponent,
    FilterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    RoutesModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatRippleModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    LayoutModule,
    MatPaginatorModule,
    HttpClientModule,
    MatSortModule,
    MatGridListModule,
    MatFormFieldModule,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
    MatChipsModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatBottomSheetModule,
    MatSlideToggleModule,
    MatCheckboxModule,
    MatStepperModule,
    MatProgressBarModule,
    MatRadioModule,
    MatCardModule,
    MsalModule.forRoot(new PublicClientApplication
      (
        {
          auth: {
            clientId: '45da1270-b42c-437c-bdf0-3c0d836f03fe',
            redirectUri: environment.urlRedirect,
            authority: 'https://login.microsoftonline.com/7006af34-cfff-40af-9dec-69a61f6cc96e'
          },
          cache:{
            cacheLocation: 'localStorage',
            storeAuthStateInCookie: isIE
          }
        }
      ),
        {
          interactionType: InteractionType.Redirect,
          authRequest: {
            scopes: ['User.Read']
          }
        },
        {
          interactionType: InteractionType.Redirect,
          protectedResourceMap: new Map(
            [
              ['https://login.microsoftonline.com/me', ['User.Read']]
            ]
          )
        }
      )
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: MsalInterceptor, multi: true
    }, MsalGuard, AzureAdService, DatePipe
  ],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
