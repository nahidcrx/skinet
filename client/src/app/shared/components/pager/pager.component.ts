import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.scss'
})
export class PagerComponent implements OnInit{
  @Input() totalCount : number;
  @Input() pageSize : number;
  @Output() pageChanged = new EventEmitter<number>();

  ngOnInit(): void {
  }

  onPageChanged(event: any){
    this.pageChanged.emit(event.page);
  }

}
