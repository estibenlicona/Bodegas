import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FilterType } from 'src/app/enums/filtertype.enum';
import { FormGroup, FormControl } from '@angular/forms';
import { IFilter } from 'src/app/interfaces/filter.interface';
import { DatePipe } from '@angular/common';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatMenuTrigger } from '@angular/material/menu';



@Component({
  selector: 'app-button-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  @Input() Column!: string;
  @Input() Class!: string;
  @Input() Type!: FilterType;
  @ViewChild('filterValue') filterValue!: ElementRef<HTMLInputElement>;
  @ViewChild('menuTrigger') menuTrigger!: MatMenuTrigger;
  selectFiltro = new FormControl('');

  filters: string[] = ['Igual', 'Diferente', 'Contiene'];
  filerSelected: string[] = [];

  today = new Date();
  month = this.today.getMonth();
  year = this.today.getFullYear();

  range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });

  @Output() changefilterEvent = new EventEmitter<IFilter>();
  @ViewChild('picker2') picker2!: ElementRef<MatDatepicker<Date>>;

  constructor
  (private datepipe: DatePipe)
  {

  }

  ngOnInit(): void {
    if(this.Type == this.FilterType.Number){
      this.filters.splice(2);
      this.filters.push('Mayor que', 'Menor que', 'Mayor igual que', 'Menor igual que', 'Entre');
    }
  }

  OnApplyFilter(){
    //(console.log(buttonFilter.templateRef.elementRef.nativeElement.toggleMenu())

    let filter: IFilter;
    if(this.range.controls.start.value != null && this.range.controls.end.value != null) {
      filter = {
        column: this.Column,
        type: 'Entre',
        value: undefined,
        start: this.datepipe.transform(this.range.controls.start.value, 'yyyy-MM-dd')?.toString(),
        end: this.datepipe.transform(this.range.controls.end.value, 'yyyy-MM-dd')?.toString()
      }
    }else {
      filter = {
        column: this.Column,
        type: this.selectFiltro.value || '',
        value: this.filterValue.nativeElement.value,
        start: undefined,
        end: undefined
      }
    }
    this.changefilterEvent.emit(filter);
    this.menuTrigger.closeMenu();
  }

  public get FilterType(): typeof FilterType {
    return FilterType;
  }
}
