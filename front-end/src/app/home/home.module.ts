import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaterialModule } from '../../material.module';

import { DashboardRoutingModule } from './home-routing.module';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

import { HistoryComponent } from './components/history/history.component';
import { SettingsComponent } from './components/settings/settings.component';
import { SearchComponent } from './components/search/search.component';
import { ChartComponent } from './components/chart/chart.component';

import { ChartModule } from '@syncfusion/ej2-angular-charts';
import {
  HiloSeriesService,
  DateTimeService,
  TooltipService,
  CrosshairService,
  HiloOpenCloseSeriesService,
  CandleSeriesService,
  DateTimeCategoryService,
} from '@syncfusion/ej2-angular-charts';

schemas: [CUSTOM_ELEMENTS_SCHEMA];

@NgModule({
  declarations: [
    SidenavComponent,
    DashboardComponent,
    HistoryComponent,
    SettingsComponent,
    SearchComponent,
    ChartComponent,
  ],
  imports: [CommonModule, DashboardRoutingModule, MaterialModule, ChartModule],
  providers: [
    HiloSeriesService,
    DateTimeService,
    TooltipService,
    CrosshairService,
    HiloOpenCloseSeriesService,
    CandleSeriesService,
    DateTimeCategoryService,
  ],
})
export class DashboardModule {}
