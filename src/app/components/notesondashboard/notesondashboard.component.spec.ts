import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotesondashboardComponent } from './notesondashboard.component';

describe('NotesondashboardComponent', () => {
  let component: NotesondashboardComponent;
  let fixture: ComponentFixture<NotesondashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotesondashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotesondashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
