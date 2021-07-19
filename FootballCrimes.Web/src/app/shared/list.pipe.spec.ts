import { ListPipe } from './list.pipe';

describe('ListPipe', () => {
  it('create an instance', () => {
    const pipe = new ListPipe();
    expect(pipe).toBeTruthy();
  });


  it('returns a comma delimited string', () => {
    const pipe = new ListPipe();
    const testArray = ["item1", "item2", "item3"];
    expect(pipe.transform(testArray)).toBe("item1, item2, item3");
  });
});
