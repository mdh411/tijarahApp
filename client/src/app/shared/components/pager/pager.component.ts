import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss'],
})
export class PagerComponent implements OnInit {
  @Input() totalCount: number; // input something we receive from parent component
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>(); // output property a way for a child component to emit output to parent

  constructor() {}

  ngOnInit(): void {}

  onPagerChanged(event: any) {
    this.pageChanged.emit(event.page);
  }
}
