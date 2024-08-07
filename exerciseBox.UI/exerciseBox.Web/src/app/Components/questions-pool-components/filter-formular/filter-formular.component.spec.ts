import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterFormularComponent } from './filter-formular.component';

describe('FilterFormularComponent', () => {
  let component: FilterFormularComponent;
  let fixture: ComponentFixture<FilterFormularComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilterFormularComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterFormularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
