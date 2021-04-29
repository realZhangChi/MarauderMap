
export function toggle(id) {
    let collapse = $('#' + id).next();
    if (collapse && collapse.attr('class').includes('collaps')) {
        collapse.collapse('toggle');
    }
}